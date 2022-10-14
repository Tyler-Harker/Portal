using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects
{
    public class CreatedAt : BaseValueObject<DateTime>
    {
        public CreatedAt(DateTime value) : base(value)
        {
        }
    }
}
