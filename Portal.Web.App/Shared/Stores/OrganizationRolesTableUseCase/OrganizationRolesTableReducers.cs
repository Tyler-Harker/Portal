using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationRolesTableUseCase
{
    public static class OrganizationRolesTableReducers
    {
        [ReducerMethod]
        public static OrganizationRolesTableState ReduceLoadOrganizationRolesTable(OrganizationRolesTableState state, LoadOrganizationRolesTable action) => state with { IsLoading = true, ErrorMessage = null, Page = null };
        [ReducerMethod]
        public static OrganizationRolesTableState ReduceLoadOrganizationRolesTableSucceded(OrganizationRolesTableState state, LoadOrganizationRolesTableSucceded action) => state with { IsLoading = false, ErrorMessage = null, Page = action.Page };
        [ReducerMethod]
        public static OrganizationRolesTableState ReduceLoadOrganizationRolesTableFailed(OrganizationRolesTableState state, LoadOrganizationRolesTableFailed action) => state with { IsLoading = false, ErrorMessage = action.ErrorMessage, Page = null };
    }
}
