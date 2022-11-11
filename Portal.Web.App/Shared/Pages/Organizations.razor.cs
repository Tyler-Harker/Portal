using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects;
using Portal.Web.Domain.HttpClients;
using Portal.Web.Domain.Stores.UserUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Web.App.Shared.Stores.OrganizationsUseCase;

namespace Portal.Web.App.Shared.Pages
{
    public partial class Organizations
    {
        [Inject]
        public WebApiHttpClient WebApiClient { get; set; }

        [Inject]
        public IState<UserState> UserState { get; set; }

        [Inject]
        public IDispatcher Dispatcher { get; set; }
        [Inject]
        public IState<OrganizationsState> OrganizationsState { get; set; }

        private MudTable<OrganizationTableData> table;
        private IEnumerable<OrganizationTableData> pagedData;

        private int totalItems;
        private string searchString = null;

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new LoadOrganizations(new SkipTake()));
            return base.OnInitializedAsync();
        }


        //private async Task<TableData<OrganizationTableData>> ServerReload(TableState state)
        //{
        //    Dispatcher.Dispatch(new LoadOrganizations(new SkipTake()));
        //    var awaitFunc = async () => { await Task.Delay(250); while (OrganizationsState.Value.IsLoading is true) { }  };
        //    await awaitFunc();

        //    return new TableData<OrganizationTableData>()
        //    {
        //        TotalItems = OrganizationsState.Value.Page?.TotalRecords ?? 0,
        //        Items = OrganizationsState.Value.Page?.Results ?? new List<OrganizationTableData>()
        //    };
        //}
    }
}
