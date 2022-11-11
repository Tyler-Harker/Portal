using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.UserUseCase
{
    public static class UserReducers
    {
        [ReducerMethod]
        public static UserState ReduceSetUserOrganizationId(UserState state, SetUserOrganizationId action) => state with { OrganizationId = action.OrganizationId };
        [ReducerMethod]
        public static UserState ReduceSetUserAccessToken(UserState state, SetUserAccessToken action) => state with { AccessToken = action.AccessToken };
        [ReducerMethod]
        public static UserState ReduceSetUserOrganizationDomain(UserState state, SetUserOrganizationDomain action) => state with { Domain= action.Domain };
        [ReducerMethod]
        public static UserState ReduceSetUserOrganizationShortName(UserState state, SetUserOrganizationShortName action) => state with { OrganizationShortName = action.ShortName };
    }
}
