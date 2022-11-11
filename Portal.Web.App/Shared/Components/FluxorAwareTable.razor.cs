using Fluxor;
using Microsoft.AspNetCore.Components;
using Portal.Domain.ValueObjects;
using Portal.Web.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Components
{
    public partial class FluxorAwareTable<TData, TState> where TState : ITableState<TData>
    {
        [Parameter]
        public RenderFragment HeaderContent { get; set; }
        [Parameter]
        public RenderFragment<TData> RowTemplate { get; set; }
        [Parameter]
        public RenderFragment? LoadingContent { get; set; }
        [Inject]
        public IState<TState> State { get; set; }

        public bool HasPreviouslyLoaded => State.Value.Page != null;


        public bool IsLoading => State.Value.IsLoading || !HasPreviouslyLoaded;




        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            State.StateChanged += (sender, args) =>
            {
                StateHasChanged();
            };
            //if(State is not null)
            //{
            //    State.StateChanged += (sender, args) =>
            //    {
            //        StateHasChanged();
            //    };
            //}
            
        }

        public IEnumerable<TData>? tableData => State.Value.Page?.Results ?? new List<TData>();
    }
}
