using Portal.Domain.Constants;
using Portal.Domain.Events.Organizations;
using Portal.Domain.Exceptions;
using Portal.Domain.Exceptions.Organizations;
using Portal.Domain.Extensions;
using Portal.Domain.GrainStates;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.UnitTests.GrainStates
{
    [TestFixture]
    public class OrganizationGrainStateTests : BaseStateTest
    {
        
    
        [Test]
        public void SetName_SetsNameAsExpected()
        {
            //setup
            var organizationName = new OrganizationName("test");
            var state = new OrganizationGrainState();

            //test
            state.Apply(new SetNameEvent(organizationName));
            Assert.That(organizationName.Equals(state.Name));
        }

        [Test]
        public void SetName_ThrowsExceptionWhenUserIdNotInContext()
        {
            //setup
            SetEmptyPrincipal();
            var organizationName = new OrganizationName("test");
            var state = new OrganizationGrainState();

            //test
            Assert.Throws<UserIdIsNotSetInRequestContextException>(() => state.Apply(new SetNameEvent(organizationName)));
        }

        [Test]
        public void CreateUserEvent_UserIdGetsAddedToActiveList()
        {
            //setup
            var state = new OrganizationGrainState();
            var userId = new UserId(Guid.NewGuid());

            //test
            state.Apply(new CreateUserEvent(userId));
            Assert.That(state.ActiveUserIds.Contains(userId));
        }
        [Test]
        public void CreateUserEvent_UserIdDoesntGetAddedToDeactivatedList()
        {
            //setup
            var state = new OrganizationGrainState();
            var userId = new UserId(Guid.NewGuid());

            //test
            state.Apply(new CreateUserEvent(userId));
            Assert.That(state.DeactivatedUserIds.Contains(userId) == false);
        }
        [Test]
        public void CreateUserEvent_ThrowsExceptionWhenAlreadyExistsInActiveUsersList()
        {
            //setup
            var state = new OrganizationGrainState();
            var userId = new UserId(Guid.NewGuid());
            state.Apply(new CreateUserEvent(userId));

            //test
            Assert.Throws<UserIdIsAlreadyActiveException>(() => state.Apply(new CreateUserEvent(userId)));
        }
        [Test]
        public void CreateUserEvent_ThrowsExceptionWhenAlreadyExistsInDeactivatedUsersList()
        {
            //setup
            var state = new OrganizationGrainState();
            var userId = new UserId(Guid.NewGuid());
            state.Apply(new CreateUserEvent(userId));
            state.Apply(new DeactivateUserEvent(userId));

            //test
            Assert.Throws<UserIdIsAlreadyDeactivatedException>(() => state.Apply(new CreateUserEvent(userId)));
        }
        [Test]
        public void CreateUserEvent_ThrowsExceptionUserIdNotSetInContext()
        {
            SetEmptyPrincipal();
            var state = new OrganizationGrainState();
            Assert.Throws<UserIdIsNotSetInRequestContextException>(() => state.Apply(new CreateUserEvent(new UserId(Guid.NewGuid()))));
        }
        [Test]
        public void DeactivateUserEvent_UserIdGetsAddedToDeactivatedUserIdsList()
        {
            //setup
            var state = new OrganizationGrainState();
            var userId = new UserId(Guid.NewGuid());
            state.Apply(new CreateUserEvent(userId));
            state.Apply(new DeactivateUserEvent(userId));

            //test
            Assert.That(state.DeactivatedUserIds.Contains(userId));
        }
        [Test]
        public void DeactivateUserEvent_UserIdIsntInActiveUserIdsList()
        {
            //setup
            var state = new OrganizationGrainState();
            var userId = new UserId(Guid.NewGuid());
            state.Apply(new CreateUserEvent(userId));
            state.Apply(new DeactivateUserEvent(userId));

            //test
            Assert.That(state.ActiveUserIds.Contains(userId) is false);
        }
        [Test]
        public void DeactivateUserEvent_ThrowsExceptionUserIdNotSetInContext()
        {
            SetEmptyPrincipal();
            var state = new OrganizationGrainState();
            Assert.Throws<UserIdIsNotSetInRequestContextException>(() => state.Apply(new DeactivateUserEvent(new UserId(Guid.NewGuid()))));
        }
        [Test]
        public void AddCustomDomainEvent_ThrowsExceptionUserIdNotSetInContext()
        {
            SetEmptyPrincipal();
            var state = new OrganizationGrainState();
            Assert.Throws<UserIdIsNotSetInRequestContextException>(() => state.Apply(new AddCustomDomainEvent(new ValueObjects.CustomDomains.Domain("test.com"))));
        }
        [Test]
        public void AddCustomDomainEvent_AddsToCustomDomainsList()
        {
            //setup
            var state = new OrganizationGrainState();
            var domain = new ValueObjects.CustomDomains.Domain("test.com");

            //test
            state.Apply(new AddCustomDomainEvent(domain));
            Assert.That(state.CustomDomains.Contains(domain));
        }
        [Test]
        public void RemoveCustomDomainEvent_ThrowsExceptionUserIdNotSetInContext()
        {
            SetEmptyPrincipal();
            var state = new OrganizationGrainState();
            Assert.Throws<UserIdIsNotSetInRequestContextException>(() => state.Apply(new RemoveCustomDomainEvent(new ValueObjects.CustomDomains.Domain("test.com"))));
        }
        [Test]
        public void RemoveCustomDomainEvent_RemovesFromCustomDomainsList()
        {
            //setup
            var state = new OrganizationGrainState();
            var domain = new ValueObjects.CustomDomains.Domain("test.com");
            state.Apply(new AddCustomDomainEvent(domain));

            //test
            state.Apply(new RemoveCustomDomainEvent(domain));
            Assert.That(state.CustomDomains.Contains(domain) is false);
        }
        [Test]
        public void RemoveCustomDomainEvent_ThrowsExceptionCustomDomainIsntAdded()
        {
            //setup
            var state = new OrganizationGrainState();
            var domain = new ValueObjects.CustomDomains.Domain("test.com");

            //test
            Assert.Throws<CustomDomainIsntAddedException>(() => state.Apply(new RemoveCustomDomainEvent(domain)));
        }


        

    }
}
