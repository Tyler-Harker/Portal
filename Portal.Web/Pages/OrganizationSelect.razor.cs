using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Web.Domain.Stores.UserOrganizationUseCase;

namespace Portal.Web.Pages
{
    public partial class OrganizationSelect
    {
        [Inject]
        IState<UserOrganizationState> OrganizationSelectState { get; set; }
        [Inject]
        IDispatcher Dispatcher { get; set; }

        bool success;
        string[] errors = { };
        MudForm form;

        public string OrganizationShortName { get; set; }
        public async Task OnSubmit()
        {
            await form.Validate();
            if (form.IsValid)
            {
                Dispatcher.Dispatch(new LoadUserOrganization(new OrganizationShortName(OrganizationShortName)));
            }
        }

        public bool IsOverlayVisible => OrganizationSelectState.Value.IsLoading;
    }
}
