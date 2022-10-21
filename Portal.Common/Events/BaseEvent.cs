using Orleans.Runtime;
using Portal.Common.Exceptions.ContextExceptions;
using Portal.Common.Extensions;
using Portal.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Events
{
    public abstract class BaseEvent : IEvent
    {
        private CreatedAt _createdAt;
        private CreatedById _createdById;
        private CreatedByImpersonatorId? _createdByImpersonatorId;

        public BaseEvent()
        {
            var loggedInUser = RequestContextExtensions.GetLoggedInUserId();
            var loggedInImpersonatorId = RequestContextExtensions.GetLoggedInImpersonatorUserId();
            if (loggedInUser == null) throw new UserIdNotSetInContextException();

            _createdAt = new CreatedAt(DateTime.UtcNow);
            _createdById = new CreatedById(loggedInUser.Value);
            _createdByImpersonatorId = loggedInImpersonatorId is null ? null : new CreatedByImpersonatorId(loggedInImpersonatorId.Value);
        }

        public CreatedAt CreatedAt => _createdAt;

        public CreatedById CreatedById => _createdById;

        public CreatedByImpersonatorId? CreatedByImpersonatorId => _createdByImpersonatorId;
    }
}
