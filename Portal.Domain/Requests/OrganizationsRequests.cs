using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Requests.Organizations
{
    public record GetOrganizationDomainInformationRequest(OrganizationShortName ShortName) : IHttpRequest;
    public record GetOrganizationsRequest(SkipTake skipTake, bool IncludeInactive = false) : IHttpRequest;
}
