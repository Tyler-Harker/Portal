using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationsUseCase
{
    public static class OrganizationsReducers
    {
        [ReducerMethod]
        public static OrganizationsState ReduceLoadOrganizations(OrganizationsState state, LoadOrganizations action) => state with { IsLoading = true, ErrorMessage = null };
        [ReducerMethod]
        public static OrganizationsState ReduceLoadOrganizationsFailed(OrganizationsState state, LoadOrganizationsFailed action) => state with { IsLoading = false, ErrorMessage = action.ErrorMessage };
        [ReducerMethod]
        public static OrganizationsState ReduceLoadOrganizationsSucceded(OrganizationsState state, LoadOrganizationsSucceded action) => state with { IsLoading = false, ErrorMessage = null, Page = action.OrganizationsPage };
    }
}
