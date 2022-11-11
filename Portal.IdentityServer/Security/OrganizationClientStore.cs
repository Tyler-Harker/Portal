using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace Portal.IdentityServer.Security
{
    public class OrganizationClientStore : IClientStore
    {
        private List<Client> Clients = new List<Client>
        {
            new Client 
            {
                ClientId = "admin",
                ClientSecrets = { new Secret("secret".Sha256())},
                AllowedGrantTypes = { AzureAdGrantValidator.Type },
                AllowedScopes = {"api", "openid"},
                AccessTokenType = AccessTokenType.Jwt,
            }
        };
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            
            return Task.FromResult(Clients.FirstOrDefault(o => o.ClientId == clientId));
        }
    }
}
