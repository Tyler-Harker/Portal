using Fluxor;
using Portal.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.SideBarUseCase
{
    public class LoadNavigationItemsEffect : Effect<LoadNavigationItems>
    {
        public override async Task HandleAsync(LoadNavigationItems action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new LoadNavigationItemsSucceded(new List<NavigationItem> { new NavigationItem("Organizations", "/organizations") }));
        }
    }
}
