using Fluxor;
using Microsoft.AspNetCore.Components;
using Portal.Domain.ValueObjects;
using Portal.Msal;
using Portal.Web.Domain.HttpClients;
using Portal.Web.Domain.Stores.UserUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.OrganizationMsalCase.Effects
{
    public class LoadOrganizationMsalConfigurationEffect : Effect<LoadOrganizationMsalConfiguration>
    {
        private readonly NavigationManager _navigationManager;
        private readonly IState<UserState> _userState;
        private readonly WebApiHttpClient _httpClient;
        private readonly MsalService _msalService;
        private readonly IdentityServerHttpClient _identityServerClient;
        private readonly AppSettings _appSettings;
        public LoadOrganizationMsalConfigurationEffect(NavigationManager navigationManager, IState<UserState> userState, WebApiHttpClient httpClient, MsalService msalService, IdentityServerHttpClient identityServerClient, AppSettings appSettings)
        {
            _navigationManager = navigationManager;
            _userState = userState;
            _httpClient = httpClient;
            _msalService = msalService;
            _identityServerClient = identityServerClient;
            _appSettings = appSettings;
        }
        public async override Task HandleAsync(LoadOrganizationMsalConfiguration action, IDispatcher dispatcher)
        {
            if(_userState.Value.OrganizationId is null)
            {
                _navigationManager.NavigateTo("/");
                return;
            }

            try
            {
                var result = await _httpClient.GetOrganizationMsalConfiguration(_userState.Value.OrganizationId);
                if(result is null)
                {
                    dispatcher.Dispatch(new LoadOrganizationMsalConfigurationFailed("Invalid Organization Id"));
                    return;
                }

                await _msalService.Init(result.Authority, result.ClientId);

                await Task.Delay(1000);

                var msalToken = await _msalService.GetToken();

                if(msalToken is null)
                {
                    await _msalService.InitiateLoginRedirect();
                }
                else
                {
                    var tokenResult = await _identityServerClient.AzureAdGrantValidator(_userState.Value.OrganizationId, msalToken);
                    if(tokenResult is not null && tokenResult.access_token is not null)
                    {
                        dispatcher.Dispatch(new SetUserAccessToken(new AccessToken(tokenResult.access_token)));
                        if(_userState.Value.Domain is null)
                        {
                            _navigationManager.NavigateTo($"https://{_userState.Value.OrganizationShortName.Value}.{_appSettings.Urls.App}/?organization_id={_userState.Value.OrganizationId.Value}&access_token={tokenResult.access_token}", true);
                        }
                        else
                        {
                            _navigationManager.NavigateTo($"{_userState.Value.Domain.Value}/?organization_id={_userState.Value.OrganizationId.Value}&access_token={tokenResult.access_token}", true);
                        }
                    }
                    else
                    {
                        _navigationManager.NavigateTo("/organization");
                        //todo handle when identtiyserver cant generate token.
                    }
                }

            }
            catch(Exception ex)
            {
                dispatcher.Dispatch(new LoadOrganizationMsalConfigurationFailed(ex.Message));   
            }

        }
    }
}
