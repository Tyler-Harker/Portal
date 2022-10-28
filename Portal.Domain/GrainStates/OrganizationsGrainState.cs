using Newtonsoft.Json;
using Portal.Domain.Events;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.GrainStates
{
    public class OrganizationsGrainState : BaseState<IOrganizationsEvent>
    {
        public Dictionary<OrganizationShortName, OrganizationId> OrganizationShortNames { get; set; } = new Dictionary<OrganizationShortName, OrganizationId>();
        public HashSet<OrganizationId> ActiveOrganizationIds { get; private set; } = new HashSet<OrganizationId>();
        public HashSet<OrganizationId> DeactivatedOrganizationIds { get; private set; } = new HashSet<OrganizationId>();

        public OrganizationsGrainState() 
        {
            
        }
        /// <summary>
        /// If the organizationid doesn't exist in active or deactivated lists; add it to the activated list.
        /// </summary>
        /// <param name="event"></param>
        public void Apply(OrganizationCreatedEvent @event) => Apply(@event, () =>
        {
            if(ActiveOrganizationIds.Contains(@event.OrganizationId) is false && DeactivatedOrganizationIds.Contains(@event.OrganizationId) is false)
            {
                ActiveOrganizationIds.Add(@event.OrganizationId);
                OrganizationShortNames.Add(@event.ShortName, @event.OrganizationId);
            }
        });

        /// <summary>
        /// Removes id from deactivated list, and adds it to activated list as long as it doesn't already exist.
        /// </summary>
        /// <param name="event"></param>
        public void Apply(OrganizationReactivatedEvent @event) => Apply(@event, () =>
        {
            DeactivatedOrganizationIds.Remove(@event.OrganizationId);
            if(ActiveOrganizationIds.Contains(@event.OrganizationId) is false)
            {
                ActiveOrganizationIds.Add(@event.OrganizationId);
            }
        });

        /// <summary>
        /// removes id from active list and adds it to deactivated list as long as it doesn't already exist.
        /// </summary>
        /// <param name="event"></param>
        public void Apply(OrganizationDeactivatedEvent @event) => Apply(@event, () =>
        {
            ActiveOrganizationIds.Remove(@event.OrganizationId);
            if(DeactivatedOrganizationIds.Contains(@event.OrganizationId) is false)
            {
                DeactivatedOrganizationIds.Add(@event.OrganizationId);
            }
        });
    }
}
