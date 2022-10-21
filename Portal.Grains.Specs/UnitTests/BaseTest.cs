using NUnit.Framework;
using Portal.Common.Constants;
using Portal.Common.Extensions;
using Portal.Common.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains.Specs.UnitTests
{
    public abstract class BaseTest
    {
        protected SiloContext Silo;

        protected UserId _loggedInUserId;
        protected ClaimsPrincipal _principal;

        public BaseTest()
        {
            
        }

        [SetUp]
        public void SetUp()
        {
            Silo = new SiloContext();
            _loggedInUserId = new UserId(Guid.NewGuid());
            _principal = new ClaimsPrincipal();
            _principal.AddIdentity(new ClaimsIdentity(new List<Claim>
            {
                new Claim(CustomClaimTypes.UserId, _loggedInUserId.ToString())
            }));
            RequestContextExtensions.SetPrincipal(_principal);
        }
    }
}
