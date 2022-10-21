using Portal.Domain.Extensions;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Events
{
    public record BaseEvent() : IEvent
    {
        public ValueObjects.UtcDateTime Time { get; } = new ValueObjects.UtcDateTime(DateTime.UtcNow);
        public UserId? LoggedInUserId { get; } = RequestContextExtensions.GetLoggedInUserId() == null ? null : RequestContextExtensions.GetLoggedInUserId();
        public UserId? ImpersonatorUserId { get; } = RequestContextExtensions.GetLoggedInImpersonatorUserId() == null ? null : RequestContextExtensions.GetLoggedInImpersonatorUserId();
    }
}
