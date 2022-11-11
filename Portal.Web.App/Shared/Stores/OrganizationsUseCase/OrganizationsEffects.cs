using Fluxor;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Web.Domain;
using Portal.Web.Domain.HttpClients;
using Portal.Web.Domain.Stores.UserUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationsUseCase
{
    public class LoadOrganizationsEffect : Effect<LoadOrganizations>
    {
        private readonly IState<UserState> _userState;
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        public LoadOrganizationsEffect(HttpClient httpClient, IState<UserState> userState, AppSettings appSettings)
        {
            _httpClient = httpClient;
            _userState = userState;
            _appSettings = appSettings;
        }
        public override async Task HandleAsync(LoadOrganizations action, IDispatcher dispatcher)
        {
            var webApiClient = new WebApiHttpClient(_httpClient, _userState, _appSettings);

            var page = await webApiClient.GetActiveOrganizations(action.SkipTake);
            dispatcher.Dispatch(new LoadOrganizationsSucceded(page));
        }
    }
}
