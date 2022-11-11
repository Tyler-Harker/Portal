using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Components.Layouts
{
    public partial class UnauthorizedLayout
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task OnClickSignIn()
        {
            NavigationManager.NavigateTo("/organization");
        }
    }
}
