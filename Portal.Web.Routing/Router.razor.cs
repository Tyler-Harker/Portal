using Fluxor;
using Microsoft.AspNetCore.Components;
using Portal.Web.Routing.Store.RoutingUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Routing
{
    public partial class Router
    {
        [Inject]
        private IState<RoutingState> RoutingState { get; set; }
    }
}
