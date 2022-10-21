using Portal.Domain.ValueObjects;
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
        ValueObjects.Users.Id LoggedInUserId { get; }
        ValueObjects.Users.Id ImpersonatorUserId { get; }
    }
}
