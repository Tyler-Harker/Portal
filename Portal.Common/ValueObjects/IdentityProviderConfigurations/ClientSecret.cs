using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects.IdentityProviderConfigurations
{
    public class ClientSecret : BaseValueObject<string>
    {
        public ClientSecret(string value) : base(value)
        {
        }
    }
}
