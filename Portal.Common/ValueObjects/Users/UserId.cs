using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects.Users
{
    public class UserId : BaseValueObject<Guid>
    {
        public UserId(Guid value) : base(value)
        {
        }
    }
}
