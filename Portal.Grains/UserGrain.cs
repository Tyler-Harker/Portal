using Orleans;
using Portal.Domain.Events.Users;
using Portal.Domain.GrainStates;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Users;
using Portal.Grains.Interfaces.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains
{
    public class UserGrain : Grain<UserGrainState>, Interfaces.Internal.IUserGrain
    {
        public Task<bool> Create(OrganizationId organizationId, UserId id, Username username, FirstName firstName, LastName lastName)
        {
            if(State.Id is null)
            {
                State.Apply(new UserCreatedEvent(organizationId, id, username, firstName, lastName));
            }
            throw new NotImplementedException();
        }

        public Task Deactivate()
        {
            return Task.FromResult(() => State.Apply(new UserDeactivatedEvent()));
        }

        public Task Reactivate()
        {
            return Task.FromResult(() => State.Apply(new UserReactivatedEvent()));
        }
    }
}
