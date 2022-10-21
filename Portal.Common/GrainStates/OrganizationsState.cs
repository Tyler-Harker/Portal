using Portal.Common.Events.OrganizationsEvents;
using Portal.Common.Exceptions.OrganizationExceptions;
using Portal.Common.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.GrainStates
{
    public class OrganizationsState : BaseState<OrganizationsId>
    {
        public Dictionary<OrganizationId, bool> ActiveOrganizationIds { get; protected set; } = new Dictionary<OrganizationId, bool>();
        public Dictionary<OrganizationId, bool> InactiveOrganizationIds { get; protected set; } = new Dictionary<OrganizationId, bool>();

        public void Apply(CreateOrganizationEvent @event) => Update(() =>
        {
            if (ActiveOrganizationIds.ContainsKey(@event.Id))
            {
                throw new OrganizationIsAlreadyCreatedException(@event.Id);
            }
            ActiveOrganizationIds.Add(@event.Id, true);
        });

        public void Apply(InactivateOrganizationEvent @event) => Update(() =>
        {
            if (ActiveOrganizationIds.Remove(@event.Id))
            {
                InactiveOrganizationIds.Add(@event.Id, true);
            }
            else
            {
                throw new OrganizationIsNotActivatedException(@event.Id);
            }
            
        });

        public void Apply(ReactivateOrganizationEvent @event) => Update(() =>
        {
            if (InactiveOrganizationIds.Remove(@event.Id))
            {
                ActiveOrganizationIds.Add(@event.Id, true);
            }
            else
            {
                throw new OrganizationIsNotInactivatedException(@event.Id);
            }
        });
    }
}
