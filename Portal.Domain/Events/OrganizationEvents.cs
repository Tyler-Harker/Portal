using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Events.Organizations
{
    public interface IOrganizationEvent : IEvent { }
    public record CreateEvent(OrganizationId id, OrganizationName name) : BaseEvent, IOrganizationEvent{}
    public record SetNameEvent(OrganizationName Name) : BaseEvent, IOrganizationEvent { }
    public record CreateUserEvent(UserId UserId) : BaseEvent, IOrganizationEvent { }
    public record DeactivateUserEvent(UserId UserId) : BaseEvent, IOrganizationEvent { }
    public record ReactivateUserEvent(UserId UserId) : BaseEvent, IOrganizationEvent { }
    public record AddCustomDomainEvent(ValueObjects.CustomDomains.Domain Domain) : BaseEvent, IOrganizationEvent { }
    public record RemoveCustomDomainEvent(ValueObjects.CustomDomains.Domain Domain) : BaseEvent, IOrganizationEvent { }
}
