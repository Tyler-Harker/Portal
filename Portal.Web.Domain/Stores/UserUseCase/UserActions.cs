using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.UserUseCase
{
    public record SetUserOrganizationId(OrganizationId OrganizationId);
    public record SetUserAccessToken(AccessToken AccessToken);
    public record SetUserOrganizationDomain(Portal.Domain.ValueObjects.CustomDomains.Domain Domain);
    public record SetUserOrganizationShortName(OrganizationShortName ShortName);
}
