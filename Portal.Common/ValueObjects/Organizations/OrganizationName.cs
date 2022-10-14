using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects.Organizations
{
    public class OrganizationName : BaseValueObject<string>
    {
        public OrganizationName(string value) : base(value)
        {
        }
    }
}
