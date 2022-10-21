using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Exceptions
{
    public abstract class BaseException : Exception { public BaseException(string message) : base(message) { } }


    public class UserIdIsNotSetInRequestContextException : BaseException { public UserIdIsNotSetInRequestContextException() : base($"UserId is not set in RequestContext.") { } }
}
