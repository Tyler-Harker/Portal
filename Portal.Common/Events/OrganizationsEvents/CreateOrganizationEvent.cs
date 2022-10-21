using Portal.Common.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Events.OrganizationsEvents
{
    public class CreateOrganizationEvent : BaseOrganizationsEvent
    {
        public OrganizationId Id { get; protected set; }
        public CreateOrganizationEvent(OrganizationId id)
        {
            Id = id;
        }
    }
}
