using Fluxor;
using Portal.Web.Routing.Store.RoutingUseCase.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Routing.Store.RoutingUseCase
{
    public static class RoutingReducers
    {
        [ReducerMethod]
        public static RoutingState ReduceNavigateToAction(RoutingState state, NavigateToAction action)
        {
            var path = state.Routes.Where(r => r.Path.Equals(action.Path)).First();

            return new RoutingState(state, currentRoute: path);
        }
        [ReducerMethod]
        public static RoutingState ReduceInitializeRoutes(RoutingState state, InitializeRoutesAction action) => new RoutingState(state, routes: action.Routes);
    }
}
