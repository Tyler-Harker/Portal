using Fluxor;
using Microsoft.AspNetCore.Components;
using Portal.Msal;
using Portal.Web.Pages;
using Portal.Web.Routing.Store.RoutingUseCase;
using Portal.Web.Routing.Store.RoutingUseCase.Actions;
using Portal.Web.Routing.Store.RoutingUseCase.Models;

namespace Portal.Web
{
    public partial class App
    {
        [Inject]
        private IState<RoutingState> RoutingState { get; set; }
        [Inject]
        private IDispatcher Dispatcher { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Dispatcher.Dispatch(new InitializeRoutesAction(new List<CustomRoute>
                {
                    new CustomRoute(new RoutePath("/"), typeof(AboutUs))
                }.AsReadOnly()));

            Dispatcher.Dispatch(new NavigateToAction(new RoutePath("/")));
        }
    }
}
