using Portal.Domain.Enums;
using Portal.Domain.Events.Organizations;
using Portal.Domain.Exceptions.Organizations;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Modules;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Security;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.GrainStates
{
    [Serializable]
    public class OrganizationGrainState : BaseState<IOrganizationEvent>
    {
        public OrganizationId? Id { get; set; }
        public OrganizationShortName? ShortName { get; set; }
        public OrganizationName? Name { get; set; }
        public HashSet<UserId> ActiveUserIds { get; set; } = new HashSet<UserId>();
        public HashSet<UserId> DeactivatedUserIds { get; set; } = new HashSet<UserId>();
        public HashSet<ValueObjects.CustomDomains.Domain> CustomDomains { get; set; } = new HashSet<ValueObjects.CustomDomains.Domain>();
        public IsActive IsActive { get; set; } = new IsActive(false);
        public OrganizationMsalConfiguration? MsalConfiguration { get; set; }
        public Dictionary<RoleName, Role> Roles { get; set; } = new Dictionary<RoleName, Role>();
        public OrganizationType Type { get; set; } = OrganizationType.Trial;
        public HashSet<ModuleName> Modules { get; set; } = new HashSet<ModuleName> { };


        /// <summary>
        /// Initializes the organization grain state
        /// </summary>
        /// <param name="event"></param>
        public void Apply(OrganizationCreatedEvent @event) => Apply(@event, () =>
        {
            Id = @event.Id;
            Name = @event.Name;
            ShortName = @event.ShortName;
            IsActive = new IsActive(true);
        });

        /// <summary>
        /// Sets the Name property of the organization grain state
        /// </summary>
        /// <param name="event"></param>
        public void Apply(OrganizationNameSetEvent @event) => Apply(@event, () =>
        {
            Name = @event.Name;
        });

        /// <summary>
        /// If the user doesn't exist in active or deactivated lists, then add it to active.
        /// </summary>
        /// <param name="event"></param>
        public void Apply(ValidUserAddedEvent @event) => Apply(@event, () =>
        {
            if(ActiveUserIds.Contains(@event.UserId) is false && DeactivatedUserIds.Contains(@event.UserId) is false)
            {
                ActiveUserIds.Add(@event.UserId);
            }
        });

        /// <summary>
        /// Removes the user from active list if it exists in there, and adds it to the deactivated list.
        /// </summary>
        /// <param name="event"></param>
        public void Apply(UserDeactivatedEvent @event) => Apply(@event, () =>
        {
            ActiveUserIds.Remove(@event.UserId);
            if(DeactivatedUserIds.Contains(@event.UserId) is false)
            {
                DeactivatedUserIds.Add(@event.UserId);
            }
        });

        /// <summary>
        /// Removes the user from the deactivated list if it exists in there, and adds it to the active list.
        /// </summary>
        /// <param name="event"></param>
        public void Apply(UserReactivatedEvent @event) => Apply(@event, () =>
        {
            DeactivatedUserIds.Remove(@event.UserId);
            if(ActiveUserIds.Contains(@event.UserId) is false)
            {
                ActiveUserIds.Add(@event.UserId);
            }
        });

        /// <summary>
        /// Adds a custom domain to the list if it doesn't already exist.
        /// </summary>
        /// <param name="event"></param>
        public void Apply(CustomDomainAddedEvent @event) => Apply(@event, () =>
        {
            if(CustomDomains.Contains(@event.Domain) is false)
            {
                CustomDomains.Add(@event.Domain);
            }
        });

        /// <summary>
        /// Removes a custom domain from the list if it exists.
        /// </summary>
        /// <param name="event"></param>
        public void Apply(CustomDomainRemovedEvent @event) => Apply(@event, () =>
        {
            CustomDomains.Remove(@event.Domain);
        });

        /// <summary>
        /// Sets the organization isActive to true
        /// </summary>
        /// <param name="event"></param>
        public void Apply(OrganizationActivatedEvent @event) => Apply(@event, () =>
        {
            IsActive = new IsActive(true);
        });

        /// <summary>
        /// set the organization isActive to false.
        /// </summary>
        /// <param name="event"></param>
        public void Apply(OrganizationDeactivatedEvent @event) => Apply(@event, () =>
        {
            IsActive = new IsActive(false);
        });

        public void Apply(OrganizationMsalConfigurationSetEvent @event) => Apply(@event, () =>
        {
            MsalConfiguration = new OrganizationMsalConfiguration(@event.Authority, @event.ClientId, @event.ClientSecret);
        });

        public void Apply(RoleCreatedEvent @event) => Apply(@event, () =>
        {
            Roles.Add(@event.Role.Name, @event.Role);
        });

        public void Apply(OrganizationTypeSetEvent @event) => Apply(@event, () =>
        {
            Type = @event.Type;
        });

        public void Apply(OrganizationModuleAdded @event) => Apply(@event, () =>
        {
            Modules.Add(@event.ModuleName);
        });

        public void Apply(OrganizationModuleRemoved @event) => Apply(@event, () =>
        {
            Modules.Remove(@event.ModuleName);
        });
    }
}
