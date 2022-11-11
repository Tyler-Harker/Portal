using Fluxor;
using Portal.Web.Domain;
using Portal.Web.Domain.HttpClients;
using Portal.Web.Domain.Stores.UserUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationFormUseCase
{
    public class LoadOrganizationEffect : Effect<LoadOrganizationForm>
    {
        private readonly IState<UserState> _userState;
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;

        public LoadOrganizationEffect(IState<UserState> userState, HttpClient httpClient, AppSettings appSettings)
        {
            _userState = userState;
            _httpClient = httpClient;
            _appSettings = appSettings;
        }

        public override async Task HandleAsync(LoadOrganizationForm action, IDispatcher dispatcher)
        {
            var webApiClient = new WebApiHttpClient(_httpClient, _userState, _appSettings);

            var response = await webApiClient.GetOrganizationById(action.Id);
            if(response is null)
            {
                dispatcher.Dispatch(new LoadOrganizationFormFailed($"Organization Not Found"));
                return;
            }

            dispatcher.Dispatch(new LoadOrganizationFormSucceded(response));
        }
    }
}
