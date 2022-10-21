using Portal.Domain.Events.Users;
using Portal.Domain.Exceptions;
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
        public UserId Id { get; private set; }
        public Username Username { get; private set; }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }

        public void Apply(CreateUserEvent @event) => Apply(@event, () =>
        {
            if (Id is not null) throw new UserIsAlreadyCreatedException(Id);

            Id = @event.Id;
            Username = @event.Username;
            FirstName = @event.FirstName;
            LastName = @event.LastName;
        });
    }
}
