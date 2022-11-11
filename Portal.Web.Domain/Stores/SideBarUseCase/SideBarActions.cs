using Portal.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.SideBarUseCase
{
    public sealed record OpenSideBar();
    public sealed record CloseSideBar();
    public sealed record LoadNavigationItems();
    public sealed record LoadNavigationItemsSucceded(List<NavigationItem> NavigationItems);
    public sealed record LoadNavigationItemsFailed(string ErrorMessage);
}
