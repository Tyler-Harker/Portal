using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects
{
    public class LastUpdatedById : BaseValueObject<Guid>
    {
        public LastUpdatedById(Guid value) : base(value)
        {
        }
    }
}
