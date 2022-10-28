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
    }
}
