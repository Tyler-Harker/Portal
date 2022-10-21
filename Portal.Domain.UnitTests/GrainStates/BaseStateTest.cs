using Portal.Domain.Constants;
using Portal.Domain.Extensions;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.UnitTests.GrainStates
{
    public abstract class BaseStateTest
    {
        protected UserId _loggedInUserId;
        protected ClaimsPrincipal _principal;

        [SetUp]
        public void SetUp()
        {
            _loggedInUserId = new UserId(Guid.NewGuid());
            _principal = new ClaimsPrincipal();
            _principal.AddIdentity(new ClaimsIdentity(new List<Claim>
            {
                new Claim(CustomClaimTypes.UserId, _loggedInUserId.Value.ToString())
            }));
            RequestContextExtensions.SetPrincipal(_principal);
        }
        protected void SetEmptyPrincipal()
        {
            var claimsPrincipal = new ClaimsPrincipal();
            RequestContextExtensions.SetPrincipal(claimsPrincipal);
        }
    }



    
}
