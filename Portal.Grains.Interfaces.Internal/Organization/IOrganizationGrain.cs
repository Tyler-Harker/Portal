using Portal.Grains.Interfaces.Internal.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains.Interfaces.Internal.Organization
{
    public interface IOrganizationGrain : Public.Organization.IOrganizationGrain
    {
        Task<IReadOnlyCollection<IUserGrain>> GetActiveUsers();

    }
}
