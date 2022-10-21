using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Events.Organizations
{
    public interface IOrganizationEvent : IEvent { }
    public record SetNameEvent(ValueObjects.Organizations.Name Name) : BaseEvent, IOrganizationEvent { }
    public record CreateUserEvent(ValueObjects.Users.Id UserId) : BaseEvent, IOrganizationEvent { }
    public record DeactivateUserEvent(ValueObjects.Users.Id UserId) : BaseEvent, IOrganizationEvent { }
    public record ReactivateUserEvent(ValueObjects.Users.Id UserId) : BaseEvent, IOrganizationEvent { }
    public record AddCustomDomainEvent(ValueObjects.CustomDomains.Domain Domain) : BaseEvent, IOrganizationEvent { }
    public record RemoveCustomDomainEvent(ValueObjects.CustomDomains.Domain Domain) : BaseEvent, IOrganizationEvent { }
}
