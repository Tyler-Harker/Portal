using Orleans;
using Portal.Common.ValueObjects;
using Portal.Common.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.GrainInterfaces
{
    public interface IOrganizationGrain : IGrainWithStringKey
    {
        Task Create(OrganizationName name);
        Task<IUserGrain> CreateUser();
        Task<List<IUserGrain>> GetUsers(SkipTake skipTake);
    }
}
