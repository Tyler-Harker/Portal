using NUnit.Framework;
using Orleans.Runtime;
using Portal.Common;
using Portal.Common.Constants;
using Portal.Common.Exceptions.GrainExceptions;
using Portal.Common.ValueObjects.Organizations;
using Portal.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains.Specs.UnitTests
{
    [TestFixture]
    public class BaseGrainTests
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
        public async Task Initialize_SetsCreatedBy()
        {
            var testGrain = await Silo.GetGrain(new TestGrainId(Guid.NewGuid()));
        }
    }

    #region testClasses
    public interface ITestBaseGrain : IGrainWithGuidKey
    {

    }

    public class TestBaseGrain : BaseGrain<TestBaseGrainState, TestGrainId>, ITestBaseGrain
    {
        protected override TestGrainId GrainId => throw new NotImplementedException();
    }

    public class TestBaseGrainState : BaseState<TestGrainId>
    {

    }

    public class TestGrainId : BaseValueObject<Guid>
    {
        public TestGrainId(Guid value) : base(value)
        {
        }
    }
    #endregion
}
