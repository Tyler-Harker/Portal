using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationUsersTableUseCase
{
    public record LoadOrganizationUsersTable(OrganizationId Id);
    public record LoadOrganizationUsersTableSucceded(Page<UserTableData> Page);
    public record LoadOrganizationUsersTableFailed(string ErrorMessage);
}
