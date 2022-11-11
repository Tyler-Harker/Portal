using Fluxor;
using Microsoft.AspNetCore.Components;
using Portal.Msal;
using Portal.Web.Domain.Stores.OrganizationMsalCase;
using Portal.Web.Domain.Stores.UserOrganizationUseCase;
using Portal.Web.Domain.Stores.UserUseCase;

namespace Portal.Web.Pages
{
    public partial class OrganizationMsal
    {
        [Inject]
        private IDispatcher Dispatcher { get; set; }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            Dispatcher.Dispatch(new LoadOrganizationMsalConfiguration());
        }
    }
}
