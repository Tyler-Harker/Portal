using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects.Organizations
{
    public class OrganizationId : BaseValueObject<string>
    {
        public OrganizationId(string value) : base(value)
        {
        }
    }
}
