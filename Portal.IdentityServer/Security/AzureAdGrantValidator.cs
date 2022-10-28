using IdentityServer4.Validation;
using Microsoft.IdentityModel.Tokens;
using Orleans;
using Portal.Domain.ValueObjects.Organizations;
using System.IdentityModel.Tokens.Jwt;
using Portal.Grains.Interfaces.Public.Extensions;

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


                var result = jwtHandler.ValidateToken(userToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    //IssuerSigningKey = new SymmetricSecurityKey(""),
                    ValidateIssuer = true,
                    ValidIssuers = new string[] { /* Audeience + /v2.0 */ },
                    ValidateAudience = true,
                    ValidAudiences = new string[] { /* ClientId */ },
                }, out token);
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
    }
}
