using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationUsersTableUseCase
{
    public static class OrganizationUsersTableReducers
    {
        [ReducerMethod]
        public static OrganizationUsersTableState ReduceLoadOrganizationUsersTable(OrganizationUsersTableState state, LoadOrganizationUsersTable action) => state with { IsLoading = true, ErrorMessage = null, Page = null };
        [ReducerMethod]
        public static OrganizationUsersTableState ReduceLoadOrganizationUsersTableSucceded(OrganizationUsersTableState state, LoadOrganizationUsersTableSucceded action) => state with { IsLoading = false, ErrorMessage = null, Page = action.Page };
        [ReducerMethod]
        public static OrganizationUsersTableState ReduceLoadOrganizationUsersTableFailed(OrganizationUsersTableState state, LoadOrganizationUsersTableFailed action) => state with { IsLoading = false, ErrorMessage = action.ErrorMessage, Page = null };

    }
}
