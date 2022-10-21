using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Events
{
    public interface IEvent
    {
        UtcDateTime Time { get; }
        UserId? LoggedInUserId { get; }
        UserId? ImpersonatorUserId { get; }
    }
}
