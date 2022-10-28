using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Events.Users
{
    public interface IUserEvent : IEvent { }
    public record UserCreatedEvent(OrganizationId OrganizationId, UserId Id, Username Username, FirstName FirstName, LastName LastName) : BaseEvent, IUserEvent;
    public record UserReactivatedEvent() : BaseEvent, IUserEvent;
    public record UserDeactivatedEvent() : BaseEvent, IUserEvent;

}
