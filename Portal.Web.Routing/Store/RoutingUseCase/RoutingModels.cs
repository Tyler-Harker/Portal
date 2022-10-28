using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Routing.Store.RoutingUseCase.Models
{
    public record RoutePath(string Value);
    public record CustomRoute(RoutePath Path, Type Component, IReadOnlyCollection<CustomRoute>? ChildRoutes = null);
}
