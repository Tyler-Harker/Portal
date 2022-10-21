using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Exceptions.ContextExceptions
{
    public class UserIdNotSetInContextException : BaseException
    {
        public UserIdNotSetInContextException() : base($"UserId is not set in RequestContext.")
        {
        }
    }
}
