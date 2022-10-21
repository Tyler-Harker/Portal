using Portal.Grains.Interfaces.Internal.Organization;
using Portal.Grains.Interfaces.Internal.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains.Organization
{
    public class OrganizationGrain : IOrganizationGrain
    {
        public Task<IReadOnlyCollection<IUserGrain>> GetActiveUsers()
        {
            throw new NotImplementedException();
        }
    }
}
