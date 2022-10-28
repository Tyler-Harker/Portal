using Orleans;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains.Interfaces.Public
{
    public interface IOrganizationsGrain : IGrainWithIntegerKey
    {
        Task<IOrganizationGrain> CreateOrganization(OrganizationShortName shortName, OrganizationName name);
        Task<IOrganizationGrain?> GetOrganization(OrganizationShortName shortName);
        Task<IOrganizationGrain?> GetOrganization(OrganizationId id);
    }
}
