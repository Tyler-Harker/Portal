using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects
{
    public class CreatedByImpersonatorId : BaseValueObject<Guid>
    {
        public CreatedByImpersonatorId(Guid value) : base(value)
        {
        }
    }
}
