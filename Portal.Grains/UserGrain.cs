using Orleans;
using Orleans.EventSourcing;
using Orleans.Providers;
using Orleans.Runtime;
using Portal.Common.GrainStates;
using Portal.GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains
{
    public class UserGrain : JournaledGrain<UserState>, IUserGrain
    {
        public UserGrain()
        {
        }
        public Task<IOrganizationGrain> GetOrganizationGrainAsync()
        {
            throw new NotImplementedException();
        }
    }
}
