using Fluxor;
using Portal.Web.Domain.Stores.UserUseCase;
using Portal.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Web.Domain.HttpClients;

namespace Portal.Web.App.Shared.Stores.OrganizationUsersTableUseCase
{
    public class LoadOrganizationUsersTableEffect : Effect<LoadOrganizationUsersTable>
    {
        private readonly IState<UserState> _userState;
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;

        public LoadOrganizationUsersTableEffect(IState<UserState> userState, HttpClient httpClient, AppSettings appSettings)
        {
            _userState = userState;
            _httpClient = httpClient;
            _appSettings = appSettings;
        }
        public override async Task HandleAsync(LoadOrganizationUsersTable action, IDispatcher dispatcher)
        {
            var webApiClient = new WebApiHttpClient(_httpClient, _userState, _appSettings);

            var userTablePage = await webApiClient.GetOrganizationUsersById(action.Id);
            if(userTablePage is null)
            {
                dispatcher.Dispatch(new LoadOrganizationUsersTableFailed("Failed to load organization users."));
            }
            dispatcher.Dispatch(new LoadOrganizationUsersTableSucceded(userTablePage));
        }
    }
}
