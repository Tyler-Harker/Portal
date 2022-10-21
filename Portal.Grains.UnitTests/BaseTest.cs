using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Portal.Domain.Constants;
using Portal.Domain.Extensions;
using Portal.Domain.ValueObjects;

namespace Portal.Grains.UnitTests
{
    public abstract class BaseTest
    {
        protected Domain.ValueObjects.Users.Id _loggedInUserId;
        protected ClaimsPrincipal _principal;

        [SetUp]
        public void SetUp()
        {
            _loggedInUserId = new Domain.ValueObjects.Users.Id(Guid.NewGuid());
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
