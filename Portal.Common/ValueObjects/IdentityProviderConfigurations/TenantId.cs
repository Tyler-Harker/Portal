using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects.IdentityProviderConfigurations
{
    public class TenantId : BaseValueObject<string>
    {
        public TenantId(string value) : base(value)
        {
        }
    }
}
