using Portal.Common.ValueObjects.IdentityProviderConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Events.OrganizationEvents
{
    public class SetIdentityProviderConfigurationIdEvent : IOrganizationEvent
    {
        public SetIdentityProviderConfigurationIdEvent(IdentityProviderConfigurationId configuration)
        {
            Configuration = configuration;
        }

        public IdentityProviderConfigurationId Configuration { get; protected set; }
    }
}
