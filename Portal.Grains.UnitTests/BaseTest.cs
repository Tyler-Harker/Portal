using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Portal.Domain.Constants;
using Portal.Domain.Extensions;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Users;

namespace Portal.Grains.UnitTests
{
    public abstract class BaseTest
    {
        protected SiloContext Silo;
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
            Silo = new SiloContext();
        }
        protected void SetEmptyPrincipal()
        {
            var claimsPrincipal = new ClaimsPrincipal();
            RequestContextExtensions.SetPrincipal(claimsPrincipal);
        }
    }
}
