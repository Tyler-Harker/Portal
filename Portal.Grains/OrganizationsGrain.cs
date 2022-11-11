using Orleans;
using Portal.Domain.GrainStates;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Users;
using Portal.Grains.Interfaces.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Grains.Interfaces.Public.Extensions;
using Portal.Grains.Interfaces.Internal.Extensions;
using Portal.Domain.Events;

namespace Portal.Grains
{
    public class OrganizationsGrain : Grain<OrganizationsGrainState>, Interfaces.Internal.IOrganizationsGrain
    {
        public async Task<IOrganizationGrain> CreateOrganization(OrganizationShortName shortName, OrganizationName name)
        {
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationGrain = GrainFactory.GetInternalGrain(organizationId);
            await organizationGrain.Create(organizationId, name, shortName);
            State.Apply(new OrganizationCreatedEvent(organizationId, shortName));
            await WriteStateAsync();
            return organizationGrain;
        }

        public Task<IOrganizationGrain?> GetOrganization(OrganizationShortName shortName)
        {
            if (State.OrganizationShortNames.ContainsKey(shortName))
            {
                var organizationId = State.OrganizationShortNames[shortName];
                if (State.ActiveOrganizationIds.Contains(organizationId))
                {
                    return Task.FromResult((IOrganizationGrain?)GrainFactory.GetGrain(organizationId));
                }
            }
            return Task.FromResult((IOrganizationGrain?)null);
        }

        public Task<IOrganizationGrain?> GetOrganization(OrganizationId id)
        {
            if (State.ActiveOrganizationIds.Contains(id))
            {
                return Task.FromResult((IOrganizationGrain?)GrainFactory.GetGrain(id));
            }
            return Task.FromResult((IOrganizationGrain?)null);
        }

        public Task<Page<IOrganizationGrain>> GetActiveOrganizations(SkipTake skipTake)
        {
            var organizationGrains = State.ActiveOrganizationIds
                .Skip(skipTake.Skip)
                .Take(skipTake.Take)
                .Select(x => GrainFactory.GetGrain(x))
                .ToList();
            return Task.FromResult(new Page<IOrganizationGrain>(skipTake, organizationGrains, State.ActiveOrganizationIds.Count)) ;
        }
    }
}
