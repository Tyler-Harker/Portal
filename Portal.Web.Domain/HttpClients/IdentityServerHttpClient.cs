using Newtonsoft.Json.Linq;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.HttpClients
{
    public class IdentityServerHttpClient
    {
        private HttpClient _httpClient;
        public IdentityServerHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7244/");
        }

        public async Task<OAuthResponse?> AzureAdGrantValidator(OrganizationId organizationId, string adIdentityToken)
        {
            var response = await _httpClient.PostAsync("connect/token", new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", "admin"),
                new KeyValuePair<string, string>("client_secret", "secret"),
                new KeyValuePair<string, string>("grant_type", "AzureAd"),
                new KeyValuePair<string, string>("organization_id", organizationId.Value.ToString()),
                new KeyValuePair<string, string>("token", adIdentityToken)
            }));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<OAuthResponse>();
            }
            else return null;
        }
    }
}
