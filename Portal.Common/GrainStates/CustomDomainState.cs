using Portal.Common.ValueObjects.CustomDomains;
using Portal.Common.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.GrainStates
{
    public class CustomDomainState : BaseState<CustomDomainId>
    {
        public OrganizationId OrganizationId { get; set; }
    }
}
