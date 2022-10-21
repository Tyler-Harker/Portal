using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Exceptions
{
    public abstract class BaseUserException : BaseException { public BaseUserException(string message) : base(message) { } }

    public class UserIsAlreadyCreatedException : BaseUserException { public UserIsAlreadyCreatedException(UserId userId) : base($"User with id: {userId} is already created.") { } }
}
