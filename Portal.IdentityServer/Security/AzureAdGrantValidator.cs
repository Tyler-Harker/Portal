using IdentityServer4.Validation;
using Microsoft.IdentityModel.Tokens;
using Orleans;
using Portal.Domain.ValueObjects.Organizations;
using System.IdentityModel.Tokens.Jwt;
using Portal.Grains.Interfaces.Public.Extensions;
using Newtonsoft.Json.Linq;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Protocols;

namespace Portal.IdentityServer.Security
{
    public class AzureAdGrantValidator : IExtensionGrantValidator
    {
        public const string Type = "AzureAd";
        public string GrantType => Type;
        private readonly ITokenValidator _tokenValidator;
        private readonly HttpClient _httpClient;
        private readonly Lazy<IClusterClient> _clusterClient;
        public AzureAdGrantValidator(ITokenValidator tokenValidator, HttpClient httpClient, Lazy<IClusterClient> clusterClient)
        {
            _tokenValidator = tokenValidator;
            _httpClient = httpClient;
            _clusterClient = clusterClient;
        }

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var organizationId = context.Request.Raw.Get("organization_id");
            var userToken = context.Request.Raw.Get("token");

            if(userToken is not null)
            {
                var jwtHandler = new JwtSecurityTokenHandler();
                var test = jwtHandler.ReadJwtToken(userToken);
                SecurityToken token;

                var organizationsGrain = _clusterClient.Value.GetGrain(new OrganizationsId());
                var organizationGrain = await organizationsGrain.GetOrganization(new OrganizationId(Guid.Parse(organizationId)));

                

                if(organizationGrain is not null)
                {
                    var msalConfiguration = await organizationGrain.GetMsalConfiguration();

                    if(msalConfiguration is not null)
                    {
                        var configUrl = $"{msalConfiguration.Authority.Value}/v2.0/.well-known/openid-configuration";
                        ConfigurationManager<OpenIdConnectConfiguration> configManager = new ConfigurationManager<OpenIdConnectConfiguration>(configUrl, new OpenIdConnectConfigurationRetriever(), _httpClient);
                        
                        var openIdConfig = await configManager.GetConfigurationAsync();
                        if(openIdConfig is not null)
                        {
                            var result = jwtHandler.ValidateToken(userToken, new TokenValidationParameters
                            {
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKeys = openIdConfig.SigningKeys,
                                ValidateIssuer = true,
                                ValidIssuers = new string[] { $"{msalConfiguration.Authority.Value}/v2.0" },
                                ValidateAudience = true,
                                ValidAudiences = new string[] { $"{msalConfiguration.Id.Value}" },
                            }, out token);

                            context.Result = new GrantValidationResult();
                        }
                    }
                }
            }
        }

        public async Task<OrganizationMsalConfiguration?> GetOrganizationMsalConfiguration(OrganizationId organizationId)
        {
            var organizationsGrain = _clusterClient.Value.GetGrain(new OrganizationsId());
            var organizationGrain = await organizationsGrain.GetOrganization(organizationId);
            if(organizationGrain is not null)
            {
            }
            return null;
        }


        internal class KeysResponse
        {
            public List<Key> Keys { get; set; }
        }

        internal class Key
        {

        }






    }
}
