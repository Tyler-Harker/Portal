using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.OrganizationMsalCase
{
    public static class OrganizationMsalReducers
    {
        [ReducerMethod]
        public static OrganizationMsalState ReduceLoadOrganizationMsalConfiguration(OrganizationMsalState state, LoadOrganizationMsalConfiguration action) => state with { IsLoading = true, ErrorMessage = null };
        [ReducerMethod]
        public static OrganizationMsalState ReduceLoadOrganizationMsalConfigurationFailed(OrganizationMsalState state, LoadOrganizationMsalConfigurationFailed action) => state with { IsLoading = false, ErrorMessage = action.ErrorMessage };
        [ReducerMethod]
        public static OrganizationMsalState ReduceLoadOrganizationMsalConfigurationSucceded(OrganizationMsalState state, LoadOrganizationMsalConfigurationSucceded action) => state with { IsLoading = false, ErrorMessage = null };
    }
}
