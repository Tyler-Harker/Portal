using Portal.Domain.Events.CustomDomains;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.GrainStates
{
    [Serializable]
    public class CustomDomainGrainState : BaseState<ICustomDomainEvent>
    {
        public ValueObjects.CustomDomains.Domain? Domain { get; private set; }
        public OrganizationId? OrganizationId { get; private set; }

        public void Apply(CustomDomainAddedEvent @event) => Apply(@event, () =>
        {
            Domain = @event.Domain;
            OrganizationId = @event.OrganizationId;
        });

        public void Apply(CustomDomainRemovedEvent @event) => Apply(@event, () =>
        {
            OrganizationId = null;
        });
    }
}
