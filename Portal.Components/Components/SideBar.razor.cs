using Fluxor;
using Microsoft.AspNetCore.Components;
using Portal.Web.Domain.Stores.SideBarUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Components.Components
{
    public partial class SideBar
    {
        [Inject]
        public IState<SideBarState> SideBarState { get; set; }
        [Inject]
        private IDispatcher Dispatcher { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Dispatcher.Dispatch(new LoadNavigationItems());
        }

    }
}
