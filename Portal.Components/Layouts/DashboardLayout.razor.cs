using Fluxor;
using Microsoft.AspNetCore.Components;
using Portal.Web.Domain.Stores.UserUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Components.Layouts
{
    public partial class DashboardLayout
    {
        [Inject]
        private IState<UserState> UserState { get; set; }
        private IDispatcher Dispatcher { get; set; }

        bool _drawerOpen = true;
        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }
    }
}
