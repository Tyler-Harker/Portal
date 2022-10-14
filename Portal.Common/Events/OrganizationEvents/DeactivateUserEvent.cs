using Portal.Common.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Events.OrganizationEvents
{
    public class DeactivateUserEvent : IOrganizationEvent
    {
        public UserId UserId { get; private set; }

        public DeactivateUserEvent(UserId userId)
        {
            if(userId == null) throw new ArgumentNullException(nameof(userId));
            UserId = userId;
        }
    }
}
