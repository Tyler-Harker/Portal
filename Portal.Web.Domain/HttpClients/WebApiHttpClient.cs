using Fluxor;
using Portal.Domain.Responses.Organizations;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Web.Domain.Stores.UserUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.HttpClients
{
    public class WebApiHttpClient
    {
        private HttpClient _httpClient;
        private readonly IState<UserState> _userState;
        public WebApiHttpClient(HttpClient httpClient, IState<UserState> userState, AppSettings appSettings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(appSettings.Urls.WebApi);
            _userState = userState;
            if(userState.Value.AccessToken is not null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", userState.Value.AccessToken.Value);
            }
        }

        public Task<GetOrganizationDomainInformationResponse?> GetOrganizationDomainInformationFromShortName(OrganizationShortName shortName)
        {
            return _httpClient.GetFromJsonAsync<GetOrganizationDomainInformationResponse>($"api/Organizations/ShortName/{shortName.Value}/DomainInformation");
        }

        public Task<GetOrganizationMsalConfigurationResponse?> GetOrganizationMsalConfiguration(OrganizationId organizationId)
        {
            return _httpClient.GetFromJsonAsync<GetOrganizationMsalConfigurationResponse>($"api/Organization/{organizationId.Value}/msalConfiguration");
        }

        public async Task<Page<OrganizationTableData>?> GetActiveOrganizations(SkipTake skipTake)
        {
            return await _httpClient.GetFromJsonAsync<Page<OrganizationTableData>>($"api/Organizations/");
        }
        public async Task<GetOrganizationByIdResponse?> GetOrganizationById(OrganizationId id)
        {
            return await _httpClient.GetFromJsonAsync<GetOrganizationByIdResponse>($"api/organization/{id.Value}");
        }

        public async Task<GetOrganizationRolesByIdResponse?> GetOrganizationRolesById(OrganizationId id)
        {
            return await _httpClient.GetFromJsonAsync<GetOrganizationRolesByIdResponse>($"api/organization/{id.Value}/roles");
        }

        public async Task<GetOrganizationUsersByIdResponse?> GetOrganizationUsersById(OrganizationId id)
        {
            return await _httpClient.GetFromJsonAsync<GetOrganizationUsersByIdResponse>($"api/organization/{id.Value}/users");
        }

    }
}
