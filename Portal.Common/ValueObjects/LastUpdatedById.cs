using Portal.Common.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects
{
    public class LastUpdatedById : UserId
    {
        public LastUpdatedById(Guid value) : base(value)
        {
        }
    }
}
