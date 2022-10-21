using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Constants
{
    public static class CustomClaimTypes
    {
        public const string Sub = "sub";
        public const string Subject = Sub;
        public const string UserId = Subject;
        public const string ImpersonatorId = "ImpersonatorId";
    }
}
