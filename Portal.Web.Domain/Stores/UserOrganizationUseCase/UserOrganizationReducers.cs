using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.UserOrganizationUseCase
{
    public static class UserOrganizationReducers
    {
        [ReducerMethod]
        public static UserOrganizationState ReduceLoadUserOrganization(UserOrganizationState state, LoadUserOrganization action) => state with { OrganizationId = null, Domain = null, IsLoading = true, ErrorMessage = null };

        [ReducerMethod]
        public static UserOrganizationState ReduceLoadUserOrganizationFailed(UserOrganizationState state, LoadUserOrganizationFailed action) => state with { OrganizationId = null, Domain = null, IsLoading = false, ErrorMessage = action.ErrorMessage };

        [ReducerMethod]
        public static UserOrganizationState ReduceLoadUserOrganizationSucceded(UserOrganizationState state, LoadUserOrganizationSuceeded action) => state with { OrganizationId = action.OrganizationId, Domain = action.OrganizationDomain, IsLoading = false, ErrorMessage = null };
    }
}
