using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Portal.Web.Domain.HttpClients;
using Portal.Web.Domain.Stores.UserUseCase;

namespace Portal.Web.Domain.Stores.UserOrganizationUseCase.Effects
{
    public class LoadUserOrganizationEffect : Effect<LoadUserOrganization>
    {
        private readonly ILogger<LoadUserOrganizationEffect> _logger;
        private readonly WebApiHttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        private readonly AppSettings _appSettings;
        public LoadUserOrganizationEffect(ILogger<LoadUserOrganizationEffect> logger, WebApiHttpClient httpClient, NavigationManager navigationManager, AppSettings appSettings)
        {
            _logger = logger;
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _appSettings = appSettings;
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
                    dispatcher.Dispatch(new SetUserOrganizationDomain(result.Domain));
                    dispatcher.Dispatch(new SetUserOrganizationShortName(result.ShortName));
                    _navigationManager.NavigateTo($"/organizationMsal");
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
