using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.SideBarUseCase
{
    public static class SideBarReducers
    {
        [ReducerMethod]
        public static SideBarState ReduceOpenSideBar(SideBarState state, OpenSideBar action) => state with { IsOpen = true };
        [ReducerMethod]
        public static SideBarState ReduceCloseSideBar(SideBarState state, CloseSideBar action) => state with { IsOpen = false };
        [ReducerMethod]
        public static SideBarState ReduceLoadNavigationItems(SideBarState state, LoadNavigationItems action) => state with { IsLoading = true, ErrorMessage = null };
        [ReducerMethod]
        public static SideBarState ReduceLoadNavigationItemsSucceded(SideBarState state, LoadNavigationItemsSucceded action) => state with { IsLoading = false, ErrorMessage = null, NavigationItems = action.NavigationItems };
        [ReducerMethod]
        public static SideBarState ReduceLoadNavigationItemsFailed(SideBarState state, LoadNavigationItemsFailed action) => state with { IsLoading = false, ErrorMessage = action.ErrorMessage, NavigationItems = null };
    }
}
