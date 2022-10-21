using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.GrainInterfaces
{
    public interface IUserGrain : IGrainWithGuidKey, IBaseGrain
    {
        Task<IOrganizationGrain> GetOrganizationGrainAsync();
    }
}
