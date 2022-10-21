using Orleans.EventSourcing;
using Portal.Common.GrainStates;
using Portal.Common.ValueObjects.IdentityProviderConfigurations;
using Portal.GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains
{
    public class IdentityProviderConfigurationGrain : BaseGrain<IdentityProviderConfigurationState, IdentityProviderConfigurationId>, IIdentityProviderConfigurationGrain
    {
        public IdentityProviderConfigurationGrain()
        {
        }

        protected override IdentityProviderConfigurationId GrainId => throw new NotImplementedException();
    }
}
