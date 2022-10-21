using Portal.Common.ValueObjects.IdentityProviderConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Events.OrganizationEvents
{
    public class SetIdentityProviderConfigurationIdEvent : BaseOrganizationEvent
    {
        public SetIdentityProviderConfigurationIdEvent(IdentityProviderConfigurationId configuration) : base()
        {
            Configuration = configuration;
        }

        public IdentityProviderConfigurationId Configuration { get; protected set; }
    }
}
