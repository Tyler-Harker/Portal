using Microsoft.AspNetCore.Http;
using Orleans;
using Orleans.Runtime;
using Portal.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Interceptors.Clients
{
    public class AddPrincipleToRequestFilter : IOutgoingGrainCallFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AddPrincipleToRequestFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task Invoke(IOutgoingGrainCallContext context)
        {

            RequestContext.Set(RequestContextConstants.IPrinciple, _httpContextAccessor.HttpContext.User);
            await context.Invoke();
        }
    }
}
