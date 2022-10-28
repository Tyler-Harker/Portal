using Portal.Web.Routing.Store.RoutingUseCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Routing.Store.RoutingUseCase.Actions
{
    public record InitializeRoutesAction(IReadOnlyCollection<CustomRoute> Routes);
    public record NavigateToAction(RoutePath Path);
}
