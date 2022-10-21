using NUnit.Framework;
using Portal.Common.Events.BaseGrainEvents;
using Portal.Common.Events.OrganizationsEvents;
using Portal.Common.Exceptions.OrganizationExceptions;
using Portal.Common.GrainStates;
using Portal.Common.ValueObjects.Organizations;
using Portal.Common.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Specs.UnitTests.States
{
    [TestFixture]
    public class OrganizationsStateTests : BaseStateTest<OrganizationsState, OrganizationsId>
    {
        public OrganizationsStateTests()
        {
        }

        protected override OrganizationsId GeneratedId => new OrganizationsId("test");

        protected override Action Setup => () => { };


        [Test]
        public void InitializeActiveOrganizationsIsEmpty()
        {
            var state = new OrganizationsState();
            state.Apply(new InitializeStateEvent<OrganizationsId>(new OrganizationsId("test")));
            Assert.IsEmpty(state.ActiveOrganizationIds);
        }
        [Test]
        public void InitializeInactivatedOrganizationIdsIsEmpty()
        {
            var state = new OrganizationsState();
            state.Apply(new InitializeStateEvent<OrganizationsId>(new OrganizationsId("test")));
            Assert.IsEmpty(state.InactiveOrganizationIds);
        }
        [Test]
        public void CreateOrganizationThrowsExceptionWhenAlreadyExists()
        {
            //setup
            var organizationId = new OrganizationId("test");
            var state = new OrganizationsState();
            state.Apply(new InitializeStateEvent<OrganizationsId>(new OrganizationsId("test")));
            state.Apply(new CreateOrganizationEvent(organizationId));

            //test
            Assert.Throws<OrganizationIsAlreadyCreatedException>(() => state.Apply(new CreateOrganizationEvent(organizationId)));

        }
        [Test]
        public void CreateOrganizationOrganizationsIdsIsNotEmpty()
        {
            //setup
            var state = new OrganizationsState();
            state.Apply(new InitializeStateEvent<OrganizationsId>(new OrganizationsId("test")));

            //test
            state.Apply(new CreateOrganizationEvent(new OrganizationId("admin")));
            Assert.IsNotEmpty(state.ActiveOrganizationIds);
        }
        [Test]
        public void CreateOrganizationOrganizationsIdsIsCountIsOne()
        {
            //setup
            var state = new OrganizationsState();
            state.Apply(new InitializeStateEvent<OrganizationsId>(new OrganizationsId("test")));

            //test
            state.Apply(new CreateOrganizationEvent(new OrganizationId("admin")));
            Assert.True(state.ActiveOrganizationIds.Count == 1);
        }
        [Test]
        public void InactivateOrganizationThrowsExceptionIfNotActivated()
        {
            //setup
            var state = new OrganizationsState();
            state.Apply(new InitializeStateEvent<OrganizationsId>(new OrganizationsId("test")));

            //test
            Assert.Throws<OrganizationIsNotActivatedException>(() => state.Apply(new InactivateOrganizationEvent(new OrganizationId("admin"))));
        }
        [Test]
        public void InactivateOrganizationInactiveOrganizationIdsIsNotEmpty()
        {
            //setup
            var organizationId = new OrganizationId("test");
            var state = new OrganizationsState();
            state.Apply(new InitializeStateEvent<OrganizationsId>(new OrganizationsId("test")));
            state.Apply(new CreateOrganizationEvent(organizationId));

            //test
            state.Apply(new InactivateOrganizationEvent(organizationId));
            Assert.IsNotEmpty(state.InactiveOrganizationIds);
        }
        [Test]
        public void InactivateOrganizationActiveOrganizationIdsIsEmpty()
        {
            //setup
            var organizationId = new OrganizationId("test");
            var state = new OrganizationsState();
            state.Apply(new InitializeStateEvent<OrganizationsId>(new OrganizationsId("test")));
            state.Apply(new CreateOrganizationEvent(organizationId));

            //test
            state.Apply(new InactivateOrganizationEvent(organizationId));
            Assert.IsEmpty(state.ActiveOrganizationIds);
        }
        [Test]
        public void ReactivateOrganizationThrowsException()
        {
            //setup
            var organizationId = new OrganizationId("test");
            var state = new OrganizationsState();
            state.Apply(new InitializeStateEvent<OrganizationsId>(new OrganizationsId("test")));

            //test
            Assert.Throws<OrganizationIsNotInactivatedException>(() => state.Apply(new ReactivateOrganizationEvent(organizationId)));
        }
        [Test]
        public void ReactivateOrganizationActiveOrganizationsIsNotEmpty()
        {
            //setup
            var organizationId = new OrganizationId("test");
            var state = new OrganizationsState();
            state.Apply(new InitializeStateEvent<OrganizationsId>(new OrganizationsId("test")));
            state.Apply(new CreateOrganizationEvent(organizationId));
            state.Apply(new InactivateOrganizationEvent(organizationId));

            //test
            state.Apply(new ReactivateOrganizationEvent(organizationId));
            Assert.IsNotEmpty(state.ActiveOrganizationIds);
        }
        [Test]
        public void ReactivateOrganizationInactiveOrganizationsIsEmpty()
        {
            //setup
            var organizationId = new OrganizationId("test");
            var state = new OrganizationsState();
            state.Apply(new InitializeStateEvent<OrganizationsId>(new OrganizationsId("test")));
            state.Apply(new CreateOrganizationEvent(organizationId));
            state.Apply(new InactivateOrganizationEvent(organizationId));

            //test
            state.Apply(new ReactivateOrganizationEvent(organizationId));
            Assert.IsEmpty(state.InactiveOrganizationIds);
        }
    }
}
