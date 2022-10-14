using Portal.Common.ValueObjects.IdentityProviderConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Events.IdentityProviderConfigurationEvents
{
    public class InitializeAsMicrosoftEvent : IIdentityProviderConfigurationEvent
    {
        public TenantId TenantId { get; protected set; }
        public Authority Authority { get; protected set; }
        public ClientId ClientId { get; protected set; }
        public ClientSecret ClientSecret { get; protected set; }

        public InitializeAsMicrosoftEvent(TenantId tenantId, Authority authority, ClientId clientId, ClientSecret clientSecret)
        {
            if (tenantId is null) throw new ArgumentNullException(nameof(tenantId));
            if (authority is null) throw new ArgumentNullException(nameof(authority));
            if (clientId is null) throw new ArgumentNullException(nameof(clientId));
            if (clientSecret is null) throw new ArgumentNullException(nameof(clientSecret));

            TenantId = tenantId;
            Authority = authority;
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
    }
}
