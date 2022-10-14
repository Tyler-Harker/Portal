using Portal.Common.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Events.OrganizationEvents
{
    public class InitializeEvent : IOrganizationEvent
    {
        public InitializeEvent(
            OrganizationId id, 
            OrganizationName name) 
        {
            if (id is null) throw new ArgumentNullException(nameof(id));
            if (name is null) throw new ArgumentNullException(nameof(name));

            Id = id;
            Name = name;
        }

        public OrganizationId Id { get; set; }
        public OrganizationName Name { get; set; }
    }
}
