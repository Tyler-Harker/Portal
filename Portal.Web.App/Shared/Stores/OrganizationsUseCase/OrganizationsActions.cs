using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationsUseCase
{
    public record LoadOrganizations(SkipTake SkipTake);
    public record LoadOrganizationsFailed(string ErrorMessage);
    public record LoadOrganizationsSucceded(Page<OrganizationTableData> OrganizationsPage);
}
