using Orleans;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains.Interfaces.Internal.Extensions
{
    public static class GrainFactoryExtensions
    {
        public static IOrganizationGrain GetInternalGrain(this IGrainFactory factory, OrganizationId id) => factory.GetGrain<IOrganizationGrain>(id.Value);
        public static IUserGrain GetInternalGrain(this IGrainFactory factory, UserId id) => factory.GetGrain<IUserGrain>(id.Value);
        public static ICustomDomainGrain GetInternalGrain(this IGrainFactory factory, Domain.ValueObjects.CustomDomains.Domain domain) => factory.GetGrain<ICustomDomainGrain>(domain.Value);
    }
}
