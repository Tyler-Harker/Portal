using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.OrganizationMsalCase
{
    public record LoadOrganizationMsalConfiguration();
    public record LoadOrganizationMsalConfigurationSucceded(OrganizationMsalConfiguration Config);
    public record LoadOrganizationMsalConfigurationFailed(string ErrorMessage);
}
