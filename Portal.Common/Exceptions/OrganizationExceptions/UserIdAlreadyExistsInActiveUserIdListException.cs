using Portal.Common.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Exceptions.OrganizationExceptions
{
    public class UserIdAlreadyExistsInActiveUserIdListException : BaseException
    {
        public UserIdAlreadyExistsInActiveUserIdListException(UserId userId) : base($"UserId: {userId} already exists in active user ids list.") { }
    }
}
