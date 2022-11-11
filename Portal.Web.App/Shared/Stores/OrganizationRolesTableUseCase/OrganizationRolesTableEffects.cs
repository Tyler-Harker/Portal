using Fluxor;
using Portal.Web.Domain.Stores.UserUseCase;
using Portal.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Web.Domain.HttpClients;

namespace Portal.Web.App.Shared.Stores.OrganizationRolesTableUseCase
{
    public class LoadOrganizationRolesTableEffect : Effect<LoadOrganizationRolesTable>
    {
        private readonly IState<UserState> _userState;
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;

        public LoadOrganizationRolesTableEffect(IState<UserState> userState, HttpClient httpClient, AppSettings appSettings)
        {
            _userState = userState;
            _httpClient = httpClient;
            _appSettings = appSettings;
        }

        public override async Task HandleAsync(LoadOrganizationRolesTable action, IDispatcher dispatcher)
        {
            var webApiClient = new WebApiHttpClient(_httpClient, _userState, _appSettings);
            var rolesPage = await webApiClient.GetOrganizationRolesById(action.Id);
            if(rolesPage is null)
            {
                dispatcher.Dispatch(new LoadOrganizationRolesTableFailed("Organization Roles does not exist."));
                return;
            }
            dispatcher.Dispatch(new LoadOrganizationRolesTableSucceded(rolesPage));
            
        }
    }
}
