using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects.IdentityProviderConfigurations
{
    public class ClientId : BaseValueObject<string>
    {
        public ClientId(string value) : base(value)
        {
        }
    }
}
