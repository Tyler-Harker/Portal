using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Portal.Domain.Extensions;
using Portal.Domain.HttpClients;
using Portal.Web.Domain.Stores.UserUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.UserOrganizationUseCase.Effects
{
    public class LoadUserOrganizationEffect : Effect<LoadUserOrganization>
    {
        private readonly ILogger<LoadUserOrganizationEffect> _logger;
        private readonly WebApiHttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public LoadUserOrganizationEffect(ILogger<LoadUserOrganizationEffect> logger, WebApiHttpClient httpClient, NavigationManager navigationManager)
        {
            _logger = logger;
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public override async Task HandleAsync(LoadUserOrganization action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Loading OrganizationSelect");

                var result = await _httpClient.GetOrganizationDomainInformationFromShortName(action.ShortName);
                if(result is null)
                {
                    dispatcher.Dispatch(new LoadUserOrganizationFailed("Organization with that name doesn't exist."));
                }
                else
                {
                    dispatcher.Dispatch(new LoadUserOrganizationSuceeded(result.OrganizationId, result.Domain));
                    dispatcher.Dispatch(new SetUserOrganizationId(result.OrganizationId));
                    _navigationManager.NavigateTo($"https://{result.Domain.Value}{_navigationManager.GetPortString()}/organizationMsal");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error fetching organizationSelect: {ex.Message}");
                dispatcher.Dispatch(new LoadUserOrganizationFailed(ex.Message));
            }
        }
    }
}
