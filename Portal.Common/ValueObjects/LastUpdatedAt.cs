using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects
{
    public class LastUpdatedAt : BaseValueObject<DateTime>
    {
        public LastUpdatedAt(DateTime value) : base(value)
        {
        }
    }
}
