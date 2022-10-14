using Orleans;
using Orleans.EventSourcing;
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
    public class CustomDomainGrain : JournaledGrain<CustomDomainState>, ICustomDomainGrain
    {
        public CustomDomainGrain()
        {
        }
    }
}
