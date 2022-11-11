using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Portal.Web.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Components
{
    public partial class FluxorAwareForm<TData, TState> where TState : IFormState<TData>
    {
        [Parameter]
        public RenderFragment FormContent { get; set; }

        [Parameter]
        public Action<TState> OnStateChange { get; set; }

        [Inject]
        public IState<TState> State { get; set; }

        public bool HasPreviouslyLoaded => State.Value.Model != null;
        public bool IsLoading => State.Value.IsLoading || !HasPreviouslyLoaded;

        public TData model;
        public MudForm form;
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            State.StateChanged += (sender, args) =>
            {
                OnStateChange?.Invoke(State.Value);
            };

        }
    }
}
