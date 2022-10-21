using Portal.Domain.Extensions;
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
        public ValueObjects.Users.Id? LoggedInUserId { get; } = RequestContextExtensions.GetLoggedInUserId() == null ? null : RequestContextExtensions.GetLoggedInUserId();
        public ValueObjects.Users.Id? ImpersonatorUserId { get; } = RequestContextExtensions.GetLoggedInImpersonatorUserId() == null ? null : RequestContextExtensions.GetLoggedInImpersonatorUserId();
    }
}
