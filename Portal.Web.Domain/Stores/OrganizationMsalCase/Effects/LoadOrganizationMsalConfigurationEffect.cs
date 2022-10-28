﻿using Fluxor;
using Microsoft.AspNetCore.Components;
using Portal.Domain.HttpClients;
using Portal.Msal;
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
        public LoadOrganizationMsalConfigurationEffect(NavigationManager navigationManager, IState<UserState> userState, WebApiHttpClient httpClient, MsalService msalService)
        {
            _navigationManager = navigationManager;
            _userState = userState;
            _httpClient = httpClient;
            _msalService = msalService;
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
                }

            }
            catch(Exception ex)
            {
                dispatcher.Dispatch(new LoadOrganizationMsalConfigurationFailed(ex.Message));   
            }

        }
    }
}