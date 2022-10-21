using Portal.Common.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects
{
    public class LastUpdatedByImpersonatorId : UserId
    {
        public LastUpdatedByImpersonatorId(Guid value) : base(value)
        {
        }
    }
}
