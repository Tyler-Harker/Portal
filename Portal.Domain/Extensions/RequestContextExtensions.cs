using Orleans.Runtime;
using Portal.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Extensions
{
    public static class RequestContextExtensions
    {
        public static void SetPrincipal(IPrincipal principal)
        {
            RequestContext.Set(RequestContextConstants.IPrinciple, principal);
            var principal2 = GetPrincipal();
        }
        public static ClaimsPrincipal? GetPrincipal()
        {
            var contextResult = RequestContext.Get(RequestContextConstants.IPrinciple);
            return (ClaimsPrincipal?)contextResult;
        }
        public static Claim? GetClaim(string claimType) => GetPrincipal()?.Claims.Where(c => c.Type == claimType).FirstOrDefault();
        public static ValueObjects.Users.Id? GetLoggedInUserId() => GetClaim(CustomClaimTypes.UserId) is null ? null : new ValueObjects.Users.Id(Guid.Parse(GetClaim(CustomClaimTypes.UserId).Value));
        public static ValueObjects.Users.Id? GetLoggedInImpersonatorUserId() => GetClaim(CustomClaimTypes.ImpersonatorId) is null ? null : new ValueObjects.Users.Id(Guid.Parse(GetClaim(CustomClaimTypes.ImpersonatorId).Value));
    }
}
