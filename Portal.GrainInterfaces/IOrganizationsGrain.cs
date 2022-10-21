using Orleans;
using Portal.Common.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.GrainInterfaces
{
    public interface IOrganizationsGrain : IGrainWithStringKey, IBaseGrain
    {
        Task Initialize();
        Task<IOrganizationGrain> CreateOrganization(OrganizationId id, OrganizationName name);
        Task DeactivateOrganization(OrganizationId id);
        Task<IOrganizationGrain> ReactivateOrganization(OrganizationId id);
        Task<IEnumerable<OrganizationId>> GetActiveOrganizationIds();

        Task<IEnumerable<IOrganizationGrain>> GetActiveOrganizations();
    }
}
