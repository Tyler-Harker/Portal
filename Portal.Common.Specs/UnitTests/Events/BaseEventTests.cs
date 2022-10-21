using NUnit.Framework;
using Orleans.Runtime;
using Portal.Common.Constants;
using Portal.Common.Events;
using Portal.Common.Exceptions.ContextExceptions;
using Portal.Common.Extensions;
using Portal.Common.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Specs.UnitTests.Events
{
    [TestFixture]
    public class BaseEventTests
    {
        private UserId _loggedInUserId;
        private ClaimsPrincipal _principal;
        private class TestBaseEvent : BaseEvent { }

        [SetUp]
        public void SetUp()
        {
            _loggedInUserId = new UserId(Guid.NewGuid());
            _principal = new ClaimsPrincipal();
            _principal.AddIdentity(new ClaimsIdentity(new List<Claim>
            {
                new Claim(CustomClaimTypes.UserId, _loggedInUserId.ToString())
            }));
            RequestContextExtensions.SetPrincipal(_principal);
        }

        [Test]
        public void DefaultThrowsExceptionIfUserIdNotSet()
        {
            var newPrincipal = new ClaimsPrincipal();
            RequestContextExtensions.SetPrincipal(newPrincipal);
            Assert.Throws<UserIdNotSetInContextException>(() => new TestBaseEvent());
        }

        [Test]
        public void DefaultSetsCreatedById()
        {
            var @event = new TestBaseEvent();
            Assert.AreEqual(_loggedInUserId.Value, @event.CreatedById.Value);
        }

        [Test]
        public void DefaultSetsCreatedAtDate()
        {
            var @event = new TestBaseEvent();
            Assert.That(@event.CreatedAt.Value > DateTime.UtcNow.AddMinutes(-1));
        }

        [Test]
        public void DefaultSetsImpersonatorId()
        {
            var impersonatorId = Guid.NewGuid();
            RequestContextExtensions.SetPrincipal(new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(CustomClaimTypes.UserId, Guid.NewGuid().ToString()),
                new Claim(CustomClaimTypes.ImpersonatorId, impersonatorId.ToString())
            })));

            var @event = new TestBaseEvent();
            Assert.AreEqual(impersonatorId, @event.CreatedByImpersonatorId.Value);
        }


    }
}
