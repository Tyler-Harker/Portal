using Fluxor;
using Microsoft.AspNetCore.Components;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Web.Domain.Stores.UserUseCase;
using System.Web;

namespace Portal.Web.App.Client
{
    public partial class MainLayout
    {
        [Inject]
        private IDispatcher Dispatcher { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var uri = new Uri(NavigationManager.Uri);
            var accessToken = HttpUtility.ParseQueryString(uri.Query).Get("access_token");
            var organizationId = HttpUtility.ParseQueryString(uri.Query).Get("organization_id");
            if(accessToken is not null)
            {
                Dispatcher.Dispatch(new SetUserAccessToken(new AccessToken(accessToken)));
            }
            if(organizationId is not null)
            {
                Dispatcher.Dispatch(new SetUserOrganizationId(new OrganizationId(Guid.Parse(organizationId))));
            }
            if(string.IsNullOrEmpty(uri.Query) is false)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
