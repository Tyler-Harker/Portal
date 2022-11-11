using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Responses.Organizations
{
    public record GetOrganizationDomainInformationResponse(OrganizationId OrganizationId, ValueObjects.CustomDomains.Domain? Domain, OrganizationShortName ShortName);
    public record GetOrganizationsResponse(Page<OrganizationTableData> organizationsPage);
}
