using Orleans.EventSourcing;
using Portal.Common.GrainStates;
using Portal.GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains
{
    public class IdentityProviderConfigurationGrain : JournaledGrain<IdentityProviderConfigurationState>, IIdentityProviderConfigurationGrain
    {
        public IdentityProviderConfigurationGrain()
        {
        }
    }
}
