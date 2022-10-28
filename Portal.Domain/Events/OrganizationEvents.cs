using Portal.Domain.ValueObjects;
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

    public record OrganizationCreatedEvent(OrganizationId Id, OrganizationName Name, OrganizationShortName ShortName) : BaseEvent, IOrganizationEvent;
    public record OrganizationNameSetEvent(OrganizationName Name) : BaseEvent, IOrganizationEvent;
    public record ValidUserAddedEvent(UserId UserId): BaseEvent, IOrganizationEvent;
    public record UserDeactivatedEvent(UserId UserId) : BaseEvent, IOrganizationEvent;
    public record UserReactivatedEvent(UserId UserId) : BaseEvent, IOrganizationEvent;
    public record CustomDomainAddedEvent(ValueObjects.CustomDomains.Domain Domain) : BaseEvent, IOrganizationEvent;
    public record CustomDomainRemovedEvent(ValueObjects.CustomDomains.Domain Domain) : BaseEvent, IOrganizationEvent;
    public record OrganizationActivatedEvent() : BaseEvent, IOrganizationEvent;
    public record OrganizationDeactivatedEvent() : BaseEvent, IOrganizationEvent;
    public record OrganizationMsalConfigurationSetEvent(Authority Authority, ClientId ClientId, ClientSecret ClientSecret) : BaseEvent, IOrganizationEvent { }
}
