using Portal.Domain.Events.Organizations;
using Portal.Domain.Exceptions.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.GrainStates
{
    public class OrganizationGrainState : BaseState<IOrganizationEvent>
    {
        public ValueObjects.Organizations.Name? Name { get; private set; }
        public HashSet<ValueObjects.Users.Id> ActiveUserIds { get; private set; } = new HashSet<ValueObjects.Users.Id>();
        public HashSet<ValueObjects.Users.Id> DeactivatedUserIds { get; private set; } = new HashSet<ValueObjects.Users.Id>();
        public HashSet<ValueObjects.CustomDomains.Domain> CustomDomains { get; private set; } = new HashSet<ValueObjects.CustomDomains.Domain>();

        public void Apply(SetNameEvent @event) => Apply(@event, () =>
        {
            Name = @event.Name;
        });

        public void Apply(CreateUserEvent @event) => Apply(@event, () =>
        {
            if (ActiveUserIds.Contains(@event.UserId))
            {
                throw new UserIdIsAlreadyActiveException(@event.UserId);
            }
            if (DeactivatedUserIds.Contains(@event.UserId))
            {
                throw new UserIdIsAlreadyDeactivatedException(@event.UserId);
            }
            ActiveUserIds.Add(@event.UserId);
        });

        public void Apply(DeactivateUserEvent @event) => Apply(@event, () =>
        {
            if (!ActiveUserIds.Remove(@event.UserId))
            {
                throw new UserIdIsNotActiveException(@event.UserId);
            }
            DeactivatedUserIds.Add(@event.UserId);
        });

        public void Apply(ReactivateUserEvent @event) => Apply(@event, () =>
        {
            if (!DeactivatedUserIds.Remove(@event.UserId))
            {
                throw new UserIdIsNotDeactivatedException(@event.UserId);
            }
            ActiveUserIds.Add(@event.UserId);
        });

        public void Apply(AddCustomDomainEvent @event) => Apply(@event, () =>
        {
            if (CustomDomains.Contains(@event.Domain))
            {
                throw new CustomDomainAlreadyAddedException(@event.Domain);
            }
            CustomDomains.Add(@event.Domain);
        });

        public void Apply(RemoveCustomDomainEvent @event) => Apply(@event, () =>
        {
            if(CustomDomains.Contains(@event.Domain) is false)
            {
                throw new CustomDomainIsntAddedException(@event.Domain);
            }
            CustomDomains.Remove(@event.Domain);
        });
    }
}
