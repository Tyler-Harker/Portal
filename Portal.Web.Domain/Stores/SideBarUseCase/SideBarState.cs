using Portal.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.SideBarUseCase
{
    public record SideBarState(List<NavigationItem>? NavigationItems = null, bool IsOpen = true, bool IsLoading = false, string? ErrorMessage = null) : BaseState(IsLoading, ErrorMessage);
}
