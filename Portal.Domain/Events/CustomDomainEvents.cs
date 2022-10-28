using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Events.CustomDomains
{
    public interface ICustomDomainEvent : IEvent { }

    public record CustomDomainAddedEvent(OrganizationId OrganizationId, ValueObjects.CustomDomains.Domain Domain) : BaseEvent, ICustomDomainEvent { }
    public record CustomDomainRemovedEvent() : BaseEvent, ICustomDomainEvent { }
}
