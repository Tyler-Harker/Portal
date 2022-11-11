using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationFormUseCase
{
    public static class OrganizationFormReducers
    {
        [ReducerMethod]
        public static OrganizationFormState ReduceLoadOrganizationForm(OrganizationFormState state, LoadOrganizationForm action) => state with { IsLoading = true, ErrorMessage = null, Model = null };
        [ReducerMethod]
        public static OrganizationFormState ReduceLoadOrganizationFormSucceded(OrganizationFormState state, LoadOrganizationFormSucceded action) => state with { IsLoading = false, ErrorMessage = null, Model = action.Response };
        [ReducerMethod]
        public static OrganizationFormState ReduceLoadOrganizationFormFailed(OrganizationFormState state, LoadOrganizationFormFailed action) => state with { IsLoading = false, ErrorMessage = action.ErrorMessage };
    }
}
