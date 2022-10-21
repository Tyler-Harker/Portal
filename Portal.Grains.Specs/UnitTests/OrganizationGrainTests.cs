using NUnit.Framework;
using Orleans.Runtime;
using Portal.Common.Constants;
using Portal.Common.Exceptions.GrainExceptions;
using Portal.Common.ValueObjects;
using Portal.Common.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains.Specs.UnitTests
{
    [TestFixture]
    public class OrganizationGrainTests
    {
        private SiloContext Silo;

        [SetUp]
        public void SetUp()
        {
            Silo = new SiloContext();
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
            claimsPrincipal.Claims.Append(new Claim(CustomClaimTypes.UserId, "a7ac5f6b-c471-42ed-99e9-c6bdebc1b5f8"));
            RequestContext.Set(RequestContextConstants.IPrinciple, claimsPrincipal);
        }

        [Test]
        public async Task BeforeInitialization_GetUsersThrowsException()
        {
            var organizationGrain = await Silo.GetGrain(new OrganizationId("test"));
            Assert.ThrowsAsync<GrainNotInitializedException>(() => organizationGrain.GetUsers(new SkipTake(0, 10)));
        }



        [Test]
        public async Task Initialize_SetsCreatedBy()
        {

        }
    }
}
