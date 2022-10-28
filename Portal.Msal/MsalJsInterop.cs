using Microsoft.JSInterop;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Msal
{
    /// <summary>
    /// https://alcdn.msauth.net/browser/2.0.0-beta.0/js/msal-browser.js
    /// </summary>
    public class MsalJsInterop : IAsyncDisposable
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
        public MsalJsInterop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
            _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Portal.Msal/msal-interop.js").AsTask());
        }

        public async Task SetMsalConfig(Authority authority, ClientId clientId)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("setMsalConfig", new
            {
                Auth = new
                {
                    ClientId = clientId.Value,
                    //RedirectUri = "https://localhost:7125",
                    Authority = authority.Value
                }
            });
        }
        public async Task SetMsalConfigDefault()
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("setMsalConfig", new
            {
                Auth = new
                {

                }
            });
        }

        public async Task CreateMsalObject()
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("createMsalObject");
        }

        public async Task InitiateLogin()
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("loginRedirect");
        }

        public async Task<string?> GetMsalAccessToken()
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<string?>("getMsalAccessToken");
        }


        public async ValueTask DisposeAsync()
        {
            if (_moduleTask.IsValueCreated)
            {
                var module = await _moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
