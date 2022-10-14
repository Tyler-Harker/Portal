using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects.CustomDomains
{
    public class CustomDomainId : BaseValueObject<string>
    {
        public CustomDomainId(string value) : base(value)
        {
        }
    }
}
