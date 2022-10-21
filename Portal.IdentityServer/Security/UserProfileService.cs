using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Security.Claims;

namespace Portal.IdentityServer.Security
{
    public class UserProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var claimsPrincipal = new ClaimsPrincipal();
            claimsPrincipal.Claims.Append(new Claim("test", "value"));
            context.Subject = new ClaimsPrincipal();
            //throw new NotImplementedException();
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            //return true;
            //throw new NotImplementedException();
        }
    }
}
