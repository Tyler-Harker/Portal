using Portal.Common.Enums;
using Portal.Common.Events.IdentityProviderConfigurationEvents;
using Portal.Common.ValueObjects.IdentityProviderConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.GrainStates
{
    public class IdentityProviderConfigurationState : BaseState<IdentityProviderConfigurationId>
    {
        public IdentityProviderType Type { get; protected set; }
        public TenantId TenantId { get; protected set; }
        public Authority Authority { get; protected set; }
        public ClientId ClientId { get; protected set; }
        public ClientSecret ClientSecret { get; protected set; }

        public IdentityProviderConfigurationState()
        {
        }


        public void Apply(InitializeAsMicrosoftEvent @event)
        {
            if (@event is null) throw new ArgumentNullException(nameof(@event));
            Type = IdentityProviderType.Microsoft;
            TenantId = @event.TenantId;
            Authority = @event.Authority;
            ClientId = @event.ClientId;
            ClientSecret = @event.ClientSecret;
        }
    }
}
