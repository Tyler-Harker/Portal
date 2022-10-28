using Portal.Domain.Responses.Organizations;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.HttpClients
{
    public class WebApiHttpClient
    {
        private HttpClient _httpClient;
        public WebApiHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<GetOrganizationDomainInformationResponse?> GetOrganizationDomainInformationFromShortName(OrganizationShortName shortName)
        {
            return _httpClient.GetFromJsonAsync<GetOrganizationDomainInformationResponse>($"api/Organizations/ShortName/{shortName.Value}/DomainInformation");
        }

        public Task<GetOrganizationMsalConfigurationResponse?> GetOrganizationMsalConfiguration(OrganizationId organizationId)
        {
            return _httpClient.GetFromJsonAsync<GetOrganizationMsalConfigurationResponse>($"api/Organization/{organizationId.Value}/msalConfiguration");
        }

    }
}
