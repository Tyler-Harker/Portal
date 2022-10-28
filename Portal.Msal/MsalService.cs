using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Msal
{
    public class MsalService
    {
        private readonly MsalJsInterop _jsInterop;
        public MsalService(MsalJsInterop jsInterop) 
        {
            _jsInterop = jsInterop;
        }

        public async Task Init(Authority authority, ClientId clientId)
        {
            await _jsInterop.SetMsalConfig(authority, clientId);
            await _jsInterop.CreateMsalObject();
        }

        public async Task<string?> GetToken()
        {
            return await _jsInterop.GetMsalAccessToken();
        }

        public async Task InitiateLoginRedirect()
        {
            await _jsInterop.InitiateLogin();
        }
    }
}
