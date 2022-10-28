using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;

namespace Portal.Grains.Interfaces.Internal
{
    public interface IOrganizationGrain : Public.IOrganizationGrain
    {
        Task<bool> Create(OrganizationId id, OrganizationName name, OrganizationShortName shortName);
    }
}
