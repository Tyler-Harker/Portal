using NUnit.Framework;
using Portal.Common.Constants;
using Portal.Common.Events.BaseGrainEvents;
using Portal.Common.Extensions;
using Portal.Common.GrainStates;
using Portal.Common.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Specs.UnitTests.States
{
    public abstract class BaseStateTest<TState, TId> : BaseTest
        where TState : BaseState<TId>, new()
        where TId : BaseValueObject
    {

        protected abstract TId GeneratedId { get; }

        [Test]
        public void BASE_STATE_InitializeCreatedAtNotNull()
        {
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.NotNull(state.CreatedAt);
        }
        [Test]
        public void BASE_STATE_InitializeCreatedAtWithinLastMinute()
        {
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.That(state.CreatedAt.Value > DateTime.UtcNow.AddMinutes(-1));
        }
        [Test]
        public void BASE_STATE_InitializeLastUpdatedAtNotNull()
        {
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.NotNull(state.LastUpdatedAt);
        }
        [Test]
        public void BASE_STATE_InitializeLastUpdatedAtWithinLastMinute()
        {
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.That(state.LastUpdatedAt.Value > DateTime.UtcNow.AddMinutes(-1));
        }
        [Test]
        public void BASE_STATE_InitializeCreatedByIdNotNull()
        {
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.NotNull(state.CreatedById);
        }
        [Test]
        public void BASE_STATE_InitializeCreatedByIdSet()
        {
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.AreEqual(_loggedInUserId.Value, state.CreatedById.Value);
        }
        [Test]
        public void BASE_STATE_InitializeLastUpdatedByIdNotNull()
        {
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.NotNull(state.LastUpdatedById);
        }
        [Test]
        public void BASE_STATE_InitializeLastUpdatedByIdSet()
        {
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.AreEqual(_loggedInUserId.Value, state.LastUpdatedById.Value);
        }
        [Test]
        public void BASE_STATE_InitializeCreatedByImpersonatorIdIsNull()
        {
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.IsNull(state.CreatedByImpersonatorId);
        }
        [Test]
        public void BASE_STATE_InitializeLastUpdatedByImpersonatorIdIsNull()
        {
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.IsNull(state.LastUpdatedByImpersonatorId);
        }
        [Test]
        public void BASE_STATE_InitializeCreatedByImpersonatorIdIsNotNull()
        {
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(CustomClaimTypes.UserId, _loggedInUserId.ToString()),
                new Claim(CustomClaimTypes.ImpersonatorId, Guid.NewGuid().ToString())
            }));
            RequestContextExtensions.SetPrincipal(claimsPrincipal);
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.IsNotNull(state.CreatedByImpersonatorId);
        }
        [Test]
        public void BASE_STATE_InitializeLastUpdatedByImpersonatorIdIsNotNull()
        {
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(CustomClaimTypes.UserId, _loggedInUserId.ToString()),
                new Claim(CustomClaimTypes.ImpersonatorId, Guid.NewGuid().ToString())
            }));
            RequestContextExtensions.SetPrincipal(claimsPrincipal);
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.IsNotNull(state.LastUpdatedByImpersonatorId);
        }
        [Test]
        public void BASE_STATE_InitializeCreatedByImpersonatorIdIsSet()
        {
            var impersonatorId = Guid.NewGuid();
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(CustomClaimTypes.UserId, _loggedInUserId.ToString()),
                new Claim(CustomClaimTypes.ImpersonatorId, impersonatorId.ToString())
            }));
            RequestContextExtensions.SetPrincipal(claimsPrincipal);
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.AreEqual(impersonatorId, state.CreatedByImpersonatorId.Value);
        }
        [Test]
        public void BASE_STATE_InitializeLastUpdatedByImpersonatorIdIsSet()
        {
            var impersonatorId = Guid.NewGuid();
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(CustomClaimTypes.UserId, _loggedInUserId.ToString()),
                new Claim(CustomClaimTypes.ImpersonatorId, impersonatorId.ToString())
            }));
            RequestContextExtensions.SetPrincipal(claimsPrincipal);
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.AreEqual(impersonatorId, state.LastUpdatedByImpersonatorId.Value);
        }
        [Test]
        public void BASE_STATE_InitializeCreatedByImpersonatorIdIsNotSameAsCreatedById()
        {
            var impersonatorId = Guid.NewGuid();
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(CustomClaimTypes.UserId, _loggedInUserId.ToString()),
                new Claim(CustomClaimTypes.ImpersonatorId, impersonatorId.ToString())
            }));
            RequestContextExtensions.SetPrincipal(claimsPrincipal);
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.AreNotEqual(impersonatorId, state.CreatedById.Value);
        }
        [Test]
        public void BASE_STATE_InitializeLastUpdatedByImpersonatorIdIsNotSameAsLastUpdatedById()
        {
            var impersonatorId = Guid.NewGuid();
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(CustomClaimTypes.UserId, _loggedInUserId.ToString()),
                new Claim(CustomClaimTypes.ImpersonatorId, impersonatorId.ToString())
            }));
            RequestContextExtensions.SetPrincipal(claimsPrincipal);
            var state = new TState();
            state.Apply(new InitializeStateEvent<TId>(GeneratedId));
            Assert.AreNotEqual(impersonatorId, state.LastUpdatedById.Value);
        }
    }
}
