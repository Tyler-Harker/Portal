using Portal.Domain.Events.Users;
using Portal.Domain.Exceptions;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.GrainStates
{
    public class UserGrainState : BaseState<IUserEvent>
    {
        public OrganizationId OrganizationId { get; private set; }
        public UserId Id { get; private set; }
        public Username Username { get; private set; }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public IsActive IsActive { get; private set; }

        public void Apply(UserCreatedEvent @event) => Apply(@event, () =>
        {
            OrganizationId = @event.OrganizationId;
            Id = @event.Id;
            Username = @event.Username;
            FirstName = @event.FirstName;
            LastName = @event.LastName;
            IsActive = new IsActive(true);
        });

        public void Apply(UserReactivatedEvent @event) => Apply(@event, () =>
        {
            IsActive = new IsActive(true);
        });

        public void Apply(UserDeactivatedEvent @event) => Apply(@event, () =>
        {
            IsActive = new IsActive(false);
        });
    }
}
