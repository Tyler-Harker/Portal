using Portal.Common.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Events.OrganizationEvents
{
    public class AddUserEvent : BaseOrganizationEvent
    {
        public UserId UserId { get; protected set; }

        public AddUserEvent(UserId userId) : base()
        {
            if(userId == null) throw new ArgumentNullException(nameof(userId));
            UserId = userId;
        }
    }
}
