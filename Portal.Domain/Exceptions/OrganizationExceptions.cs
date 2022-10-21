using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Exceptions.Organizations
{
    public abstract class BaseOrganizationException : BaseException { public BaseOrganizationException(string message) : base(message) { } }


    public class UserIdIsAlreadyActiveException : BaseOrganizationException { public UserIdIsAlreadyActiveException(ValueObjects.Users.Id userId) : base($"User with id: {userId} is already active.") { } }
    public class UserIdIsAlreadyDeactivatedException : BaseOrganizationException { public UserIdIsAlreadyDeactivatedException(ValueObjects.Users.Id userId) : base($"User with id: {userId} is already deactivated.") { } }
    public class UserIdIsNotActiveException : BaseOrganizationException { public UserIdIsNotActiveException(ValueObjects.Users.Id userId) : base($"User with id: {userId} is not active.") { } }
    public class UserIdIsNotDeactivatedException : BaseOrganizationException { public UserIdIsNotDeactivatedException(ValueObjects.Users.Id userId) : base($"User with id: {userId} is not deactivated.") { } }
    public class CustomDomainAlreadyAddedException : BaseOrganizationException { public CustomDomainAlreadyAddedException(ValueObjects.CustomDomains.Domain domain) : base($"CustomDomain with domain: {domain} is already added.") { } }
    public class CustomDomainIsntAddedException : BaseOrganizationException { public CustomDomainIsntAddedException(ValueObjects.CustomDomains.Domain domain) : base($"CustomDomain with domain: {domain} isn't added.") { } }
}
