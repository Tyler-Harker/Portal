using Portal.Domain.ValueObjects.Users;
using Portal.Domain.ValueObjects;
using Portal.Web.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationUsersTableUseCase
{
    public record OrganizationUsersTableState(Page<UserTableData>? Page = null, bool IsLoading = false, string? ErrorMessage = null) : BaseState(IsLoading, ErrorMessage), ITableState<UserTableData>;
}
