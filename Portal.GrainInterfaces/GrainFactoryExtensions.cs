using Orleans;
using Portal.Common.ValueObjects.CustomDomains;
using Portal.Common.ValueObjects.IdentityProviderConfigurations;
using Portal.Common.ValueObjects.Organizations;
using Portal.Common.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.GrainInterfaces
{
    public static class GrainFactoryExtensions
    {
        public static IOrganizationGrain GetGrain(this IGrainFactory factory, OrganizationId organizationId) => factory.GetGrain<IOrganizationGrain>(organizationId.Value);
        public static IUserGrain GetGrain(this IGrainFactory factory, UserId userId) => factory.GetGrain<IUserGrain>(userId.Value);
        public static IIdentityProviderConfigurationGrain GetGrain(this IGrainFactory factory, IdentityProviderConfigurationId identityProviderConfigurationId) => factory.GetGrain<IIdentityProviderConfigurationGrain>(identityProviderConfigurationId.Value);
        public static ICustomDomainGrain GetGrain(this IGrainFactory factory, CustomDomainId customDomainId) => factory.GetGrain<ICustomDomainGrain>(customDomainId.Value);
    }
}
