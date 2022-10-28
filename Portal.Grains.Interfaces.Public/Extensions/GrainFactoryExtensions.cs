using Orleans;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains.Interfaces.Public.Extensions
{
    public static class GrainFactoryExtensions
    {
        public static IOrganizationsGrain GetGrain(this IGrainFactory factory, OrganizationsId id) => factory.GetGrain<IOrganizationsGrain>(0);
        public static IOrganizationGrain GetGrain(this IGrainFactory factory, OrganizationId organizationId) => factory.GetGrain<IOrganizationGrain>(organizationId.Value);
        public static IUserGrain GetGrain(this IGrainFactory factory, UserId userId) => factory.GetGrain<IUserGrain>(userId.Value);
        public static ICustomDomainGrain GetGrain(this IGrainFactory factory, Domain.ValueObjects.CustomDomains.Domain domain) => factory.GetGrain<ICustomDomainGrain>(domain.Value);
    }
}
