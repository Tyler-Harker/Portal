using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects
{
    public class IsActive : BaseValueObject<bool>
    {
        public IsActive(bool value) : base(value)
        {
        }
    }
}
