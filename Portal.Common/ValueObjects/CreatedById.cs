using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects
{
    public class CreatedById : BaseValueObject<Guid>
    {
        public CreatedById(Guid value) : base(value)
        {
        }
    }
}
