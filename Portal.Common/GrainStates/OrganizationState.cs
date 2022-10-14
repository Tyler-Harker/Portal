using Portal.Common.Events.OrganizationEvents;
using Portal.Common.Exceptions.OrganizationExceptions;
using Portal.Common.ValueObjects.IdentityProviderConfigurations;
using Portal.Common.ValueObjects.Organizations;
using Portal.Common.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.GrainStates
{
    [Serializable]
    public class OrganizationState : BaseState<OrganizationId>
    {

        public OrganizationName Name { get; protected set; }
        public ICollection<UserId> ActiveUserIds { get; protected set; } = new List<UserId>();
        public ICollection<UserId> DeactivatedUserIds { get; protected set; } = new List<UserId>();
        public IdentityProviderConfigurationId? IdentityProviderConfigurationId { get; protected set; }

        public void Apply(InitializeEvent @event)
        {
            if(Id != null)
            {
                throw new OrganizationAlreadyInitializedException(Id);
            }
            Id = @event.Id;
            Name = @event.Name;
        }

        public void Apply(AddUserEvent @event)
        {
            if (!ActiveUserIds.Contains(@event.UserId))
            {
                ActiveUserIds.Add(@event.UserId);
            }
            else
            {
                throw new UserIdAlreadyExistsInActiveUserIdListException(@event.UserId);
            }
            
        }
        public void Apply(DeactivateUserEvent @event)
        {
            if (ActiveUserIds.Remove(@event.UserId))
            {
                DeactivatedUserIds.Add(@event.UserId);
            }
            else
            {
                throw new UserIdDoesNotExistInActiveUserIdsListException(@event.UserId);
            }
        }

        public void Apply(SetIdentityProviderConfigurationIdEvent @event)
        {
            IdentityProviderConfigurationId = @event.Configuration;
        }

    }
}
