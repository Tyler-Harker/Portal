using NUnit.Framework;
using Portal.Common.Events.OrganizationEvents;
using Portal.Common.GrainStates;
using Portal.Common.ValueObjects.IdentityProviderConfigurations;
using Portal.Common.ValueObjects.Organizations;
using Portal.Common.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Specs.UnitTests.States
{
    [TestFixture]
    public class OrganizationStateTests : BaseStateTest<OrganizationState, OrganizationId>
    {
        protected override OrganizationId GeneratedId => new OrganizationId("admin");

        protected override Action Setup => () => { };


        [Test]
        public void NotInitialized_InitializeEvent_SetsName()
        {
            var organizationId = new OrganizationId("admin");
            var organizationName = new OrganizationName("admin org");
            var state = new OrganizationState();
            state.Apply(new InitializeEvent(organizationId, organizationName));
            Assert.AreEqual(organizationName, state.Name);
        }
        [Test]
        public void Initialized_AddUserEvent_AddsToActiveUserIds()
        {
            //setup
            var organizationId = new OrganizationId("admin");
            var organizationName = new OrganizationName("admin org");
            var state = new OrganizationState();
            state.Apply(new InitializeEvent(organizationId, organizationName));
            var userId = new UserId(Guid.NewGuid());

            //test
            state.Apply(new AddUserEvent(userId));
            Assert.Contains(userId, state.ActiveUserIds.ToList());
        }
        [Test]
        public void Initialized_AddUserEvent_DoesntAddToDeactivatedUserIds()
        {
            //setup
            var organizationId = new OrganizationId("admin");
            var organizationName = new OrganizationName("admin org");
            var state = new OrganizationState();
            state.Apply(new InitializeEvent(organizationId, organizationName));
            var userId = new UserId(Guid.NewGuid());

            //test
            state.Apply(new AddUserEvent(userId));
            Assert.IsFalse(state.DeactivatedUserIds.Contains(userId));
        }
        [Test]
        public void Initialized_DeactivateUserEvent_AddsToDeactivatedUserIds()
        {
            //setup
            var organizationId = new OrganizationId("admin");
            var organizationName = new OrganizationName("admin org");
            var state = new OrganizationState();
            state.Apply(new InitializeEvent(organizationId, organizationName));
            var userId = new UserId(Guid.NewGuid());
            state.Apply(new AddUserEvent(userId));

            //test
            state.Apply(new DeactivateUserEvent(userId));
            Assert.Contains(userId, state.DeactivatedUserIds.ToList());
        }
        [Test]
        public void Initialized_DeactivateUserEvent_RemovesFromActivatedUserIds()
        {
            //setup
            var organizationId = new OrganizationId("admin");
            var organizationName = new OrganizationName("admin org");
            var state = new OrganizationState();
            state.Apply(new InitializeEvent(organizationId, organizationName));
            var userId = new UserId(Guid.NewGuid());
            state.Apply(new AddUserEvent(userId));

            //test
            state.Apply(new DeactivateUserEvent(userId));
            Assert.IsFalse(state.ActiveUserIds.Contains(userId));
        }
        [Test]
        public void Initialized_SetIdentityProviderConfigurationIdEvent_SetsIdentityProviderConfigurationId()
        {
            //setup
            var organizationId = new OrganizationId("admin");
            var organizationName = new OrganizationName("admin org");
            var state = new OrganizationState();
            state.Apply(new InitializeEvent(organizationId, organizationName));
            var identityProviderConfigurationId = new IdentityProviderConfigurationId(Guid.NewGuid());

            //test
            state.Apply(new SetIdentityProviderConfigurationIdEvent(identityProviderConfigurationId));
            Assert.AreEqual(identityProviderConfigurationId, state.IdentityProviderConfigurationId);
        }


    }
}
