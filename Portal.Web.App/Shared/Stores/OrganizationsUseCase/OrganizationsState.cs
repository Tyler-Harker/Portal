using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Web.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationsUseCase
{
    public record OrganizationsState(SkipTake SkipTake, Page<OrganizationTableData>? Page = null, bool IsLoading = false, string? ErrorMessage = null) : BaseState(IsLoading, ErrorMessage), ITableState<OrganizationTableData>;
}
