using Fluxor;
using Portal.Web.Routing.Store.RoutingUseCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Routing.Store.RoutingUseCase
{
    [FeatureState]
    public class RoutingState : BaseState
    {
        public IReadOnlyCollection<CustomRoute>? Routes { get; }
        public CustomRoute? CurrentRoute { get; }

        public RoutingState(): base(true, null)
        {
        }

        public RoutingState(RoutingState old, IReadOnlyCollection<CustomRoute>? routes = null, CustomRoute? currentRoute = null) : base(false, null)
        {
            this.CurrentRoute = old.CurrentRoute;
            this.Routes = old.Routes;

            if(currentRoute is not null) { this.CurrentRoute = currentRoute; }
            if(routes is not null) { this.Routes = routes; }
        }
    }
}
