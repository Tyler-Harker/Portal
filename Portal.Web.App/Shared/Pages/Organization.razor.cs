using Fluxor;
using Microsoft.AspNetCore.Components;
using Portal.Domain.Responses.Organizations;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Web.App.Shared.Stores.OrganizationFormUseCase;
using Portal.Web.App.Shared.Stores.OrganizationRolesTableUseCase;
using Portal.Web.App.Shared.Stores.OrganizationUsersTableUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Pages
{
    public partial class Organization
    {
        [Parameter()]
        public Guid OrganizationIdGuid { get; set; }

        public string? Name { get; set; }
        public string? ShortName { get; set; }

        [Inject]
        public IDispatcher Dispatcher { get; set; }

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new LoadOrganizationForm(new OrganizationId(OrganizationIdGuid)));
            Dispatcher.Dispatch(new LoadOrganizationRolesTable(new OrganizationId(OrganizationIdGuid)));
            Dispatcher.Dispatch(new LoadOrganizationUsersTable(new OrganizationId(OrganizationIdGuid)));
            return base.OnInitializedAsync();
        }

        public void OnStateChange(OrganizationFormState state)
        {
            Name = state.Model?.Name?.Value;
            ShortName = state.Model?.ShortName?.Value;
            StateHasChanged();
        }
    }
}
