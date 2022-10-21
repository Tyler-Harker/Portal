using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects.Organizations
{
    public class OrganizationsId : BaseValueObject<string>
    {
        public OrganizationsId(string value) : base(value)
        {
        }
    }
}
