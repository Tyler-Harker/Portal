using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationRolesTableUseCase
{
    public record LoadOrganizationRolesTable(OrganizationId Id);
    public record LoadOrganizationRolesTableSucceded(Page<Role> Page);
    public record LoadOrganizationRolesTableFailed(string ErrorMessage);
}
