using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects.IdentityProviderConfigurations
{
    public class IdentityProviderConfigurationId : BaseValueObject<Guid>
    {
        public IdentityProviderConfigurationId(Guid value) : base(value)
        {
        }
    }
}
