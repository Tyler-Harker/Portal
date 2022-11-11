using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace Portal.IdentityServer.Security
{
    public class ResourceStore : IResourceStore
    {
        private List<ApiResource> ApiResources = new List<ApiResource>
        {
            new ApiResource
            {
                Name = "WebApi",
                DisplayName = "WebApi",
                Description = "Allow the application to access WebApi on your behalf",
                Scopes =
                {
                    "api", "openid"
                },
                UserClaims =
                {
                    "role", "user"
                }
            }
        };
        private List<ApiScope> ApiScopes = new List<ApiScope>()
        {
            new ApiScope("api")
        };
        private List<IdentityResource> IdentityResources = new List<IdentityResource>();

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            return ApiResources.Where(r => apiResourceNames.Contains(r.Name));
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            return ApiResources.Where(r => r.Scopes.Where(s => scopeNames.Contains(s)).FirstOrDefault() != null);
        }

        public async Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            return ApiScopes.Where(s => scopeNames.Contains(s.Name));
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            return Task.FromResult(new Resources(IdentityResources, ApiResources, ApiScopes));
        }
    }
}
