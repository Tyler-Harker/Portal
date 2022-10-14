using Portal.Common.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Exceptions.OrganizationExceptions
{
    public class UserIdDoesNotExistInActiveUserIdsListException : BaseException
    {
        public UserIdDoesNotExistInActiveUserIdsListException(UserId userId) : base($"UserId: {userId} does not exist in Active User Ids List.") { }
    }
}
