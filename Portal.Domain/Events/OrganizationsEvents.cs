using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Events
{
    public interface IOrganizationsEvent : IEvent { }

    public record OrganizationCreatedEvent(OrganizationId OrganizationId, OrganizationShortName ShortName) : BaseEvent, IOrganizationsEvent { }
    public record OrganizationReactivatedEvent(OrganizationId OrganizationId) : BaseEvent, IOrganizationsEvent { }
    public record OrganizationDeactivatedEvent(OrganizationId OrganizationId) : BaseEvent, IOrganizationsEvent { }
}
