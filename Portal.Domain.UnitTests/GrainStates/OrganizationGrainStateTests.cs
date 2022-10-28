using Portal.Domain.Constants;
using Portal.Domain.Events.Organizations;
using Portal.Domain.Exceptions;
using Portal.Domain.Exceptions.Organizations;
using Portal.Domain.Extensions;
using Portal.Domain.GrainStates;
using Portal.Domain.ValueObjects;
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
        public void OrganizationCreatedEvent_SetsId()
        {
            //setup
            var state = new OrganizationGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin corp");
            var organizationShortName = new OrganizationShortName("admin");

            //test
            state.Apply(new OrganizationCreatedEvent(organizationId, organizationName, organizationShortName));
            Assert.That(organizationId, Is.EqualTo(state.Id));
        }

        [Test]
        public void OrganizationCreatedEvent_SetsName()
        {
            //setup
            var state = new OrganizationGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin corp");
            var organizationShortName = new OrganizationShortName("admin");

            //test
            state.Apply(new OrganizationCreatedEvent(organizationId, organizationName, organizationShortName));
            Assert.That(organizationName, Is.EqualTo(state.Name));
        }

        [Test]
        public void OrganizationCreatedEvent_SetsShortName()
        {
            //setup
            var state = new OrganizationGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin corp");
            var organizationShortName = new OrganizationShortName("admin");

            //test
            state.Apply(new OrganizationCreatedEvent(organizationId, organizationName, organizationShortName));
            Assert.That(organizationShortName, Is.EqualTo(state.ShortName));
        }

        [Test]
        public void OrganizationActivatedEvent_SetsActiveTrue()
        {
            //setup
            var state = new OrganizationGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin corp");
            var organizationShortName = new OrganizationShortName("admin");
            state.Apply(new OrganizationCreatedEvent(organizationId, organizationName, organizationShortName));

            //test
            state.Apply(new OrganizationActivatedEvent());
            Assert.That(state.IsActive, Is.EqualTo(new IsActive(true)));
        }

        [Test]
        public void OrganizationDeactivatedEvent_SetsActiveFalse()
        {
            //setup
            var state = new OrganizationGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin corp");
            var organizationShortName = new OrganizationShortName("admin");
            state.Apply(new OrganizationCreatedEvent(organizationId, organizationName, organizationShortName));

            //test
            state.Apply(new OrganizationDeactivatedEvent());
            Assert.That(state.IsActive, Is.EqualTo(new IsActive(false)));
        }

        [Test]
        public void ValidUserAddedEvent_AddsUserToActiveList()
        {
            //setup
            var state = new OrganizationGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin corp");
            var organizationShortName = new OrganizationShortName("admin");
            state.Apply(new OrganizationCreatedEvent(organizationId, organizationName, organizationShortName));
            var newUserId = new UserId(Guid.NewGuid());

            //test
            state.Apply(new ValidUserAddedEvent(newUserId));
            Assert.That(state.ActiveUserIds.Contains(newUserId), Is.True);
        }

        [Test]
        public void ValidUserAddedEvent_DoesntExistInDeactivatedList()
        {
            //setup
            var state = new OrganizationGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin corp");
            var organizationShortName = new OrganizationShortName("admin");
            state.Apply(new OrganizationCreatedEvent(organizationId, organizationName, organizationShortName));
            var newUserId = new UserId(Guid.NewGuid());

            //test
            state.Apply(new ValidUserAddedEvent(newUserId));
            Assert.That(state.DeactivatedUserIds.Contains(newUserId), Is.False);
        }

        [Test]
        public void UserDeactivatedEvent_AddsUserToDeactivatedList()
        {
            //setup
            var state = new OrganizationGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin corp");
            var organizationShortName = new OrganizationShortName("admin");
            state.Apply(new OrganizationCreatedEvent(organizationId, organizationName, organizationShortName));
            var newUserId = new UserId(Guid.NewGuid());

            //test
            state.Apply(new UserDeactivatedEvent(newUserId));
            Assert.That(state.DeactivatedUserIds.Contains(newUserId), Is.True);
        }

        [Test]
        public void UserDeactivedEvent_UserGetsRemovedFromActiveList()
        {
            //setup
            var state = new OrganizationGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin corp");
            var organizationShortName = new OrganizationShortName("admin");
            state.Apply(new OrganizationCreatedEvent(organizationId, organizationName, organizationShortName));
            var newUserId = new UserId(Guid.NewGuid());
            state.Apply(new ValidUserAddedEvent(newUserId));

            //test
            state.Apply(new UserDeactivatedEvent(newUserId));
            Assert.That(state.ActiveUserIds.Contains(newUserId), Is.False);
        }

        [Test]
        public void UserRectivatedEvent_UserGetsAddedBackToActiveList()
        {
            //setup
            var state = new OrganizationGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin corp");
            var organizationShortName = new OrganizationShortName("admin");
            state.Apply(new OrganizationCreatedEvent(organizationId, organizationName, organizationShortName));
            var newUserId = new UserId(Guid.NewGuid());
            state.Apply(new ValidUserAddedEvent(newUserId));
            state.Apply(new UserDeactivatedEvent(newUserId));

            //test
            state.Apply(new UserReactivatedEvent(newUserId));
            Assert.That(state.ActiveUserIds.Contains(newUserId), Is.True);
        }

        [Test]
        public void UserRectivatedEvent_UserGetsRemovedFromDeactivatedList()
        {
            //setup
            var state = new OrganizationGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin corp");
            var organizationShortName = new OrganizationShortName("admin");
            state.Apply(new OrganizationCreatedEvent(organizationId, organizationName, organizationShortName));
            var newUserId = new UserId(Guid.NewGuid());
            state.Apply(new ValidUserAddedEvent(newUserId));
            state.Apply(new UserDeactivatedEvent(newUserId));

            //test
            state.Apply(new UserReactivatedEvent(newUserId));
            Assert.That(state.DeactivatedUserIds.Contains(newUserId), Is.False);
        }

        [Test]
        public void CustomDomainAddedEvent_GetsAddedToCustomDomainsList()
        {
            //setup
            var state = new OrganizationGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin corp");
            var organizationShortName = new OrganizationShortName("admin");
            state.Apply(new OrganizationCreatedEvent(organizationId, organizationName, organizationShortName));
            var newDomain = new ValueObjects.CustomDomains.Domain("test.com");

            //test
            state.Apply(new CustomDomainAddedEvent(newDomain));
            Assert.That(state.CustomDomains.Contains(newDomain), Is.True);
        }

        [Test]
        public void CustomDomainRemovedEvent_GetsRemovedFromCustomDomainsList()
        {
            //setup
            var state = new OrganizationGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin corp");
            var organizationShortName = new OrganizationShortName("admin");
            state.Apply(new OrganizationCreatedEvent(organizationId, organizationName, organizationShortName));
            var newDomain = new ValueObjects.CustomDomains.Domain("test.com");
            state.Apply(new CustomDomainAddedEvent(newDomain));

            //test
            state.Apply(new CustomDomainRemovedEvent(newDomain));
            Assert.That(state.CustomDomains.Contains(newDomain), Is.False);
        }






        //[Test]
        //public void SetName_SetsNameAsExpected()
        //{
        //    //setup
        //    var organizationName = new OrganizationName("test");
        //    var state = new OrganizationGrainState();

        //    //test
        //    state.Apply(new SetNameEvent(organizationName));
        //    Assert.That(organizationName.Equals(state.Name));
        //}

        //[Test]
        //public void SetName_ThrowsExceptionWhenUserIdNotInContext()
        //{
        //    //setup
        //    SetEmptyPrincipal();
        //    var organizationName = new OrganizationName("test");
        //    var state = new OrganizationGrainState();

        //    //test
        //    Assert.Throws<UserIdIsNotSetInRequestContextException>(() => state.Apply(new SetNameEvent(organizationName)));
        //}

        //[Test]
        //public void CreateUserEvent_UserIdGetsAddedToActiveList()
        //{
        //    //setup
        //    var state = new OrganizationGrainState();
        //    var userId = new UserId(Guid.NewGuid());

        //    //test
        //    state.Apply(new CreateUserEvent(userId));
        //    Assert.That(state.ActiveUserIds.Contains(userId));
        //}
        //[Test]
        //public void CreateUserEvent_UserIdDoesntGetAddedToDeactivatedList()
        //{
        //    //setup
        //    var state = new OrganizationGrainState();
        //    var userId = new UserId(Guid.NewGuid());

        //    //test
        //    state.Apply(new CreateUserEvent(userId));
        //    Assert.That(state.DeactivatedUserIds.Contains(userId) == false);
        //}
        //[Test]
        //public void CreateUserEvent_ThrowsExceptionWhenAlreadyExistsInActiveUsersList()
        //{
        //    //setup
        //    var state = new OrganizationGrainState();
        //    var userId = new UserId(Guid.NewGuid());
        //    state.Apply(new CreateUserEvent(userId));

        //    //test
        //    Assert.Throws<UserIdIsAlreadyActiveException>(() => state.Apply(new CreateUserEvent(userId)));
        //}
        //[Test]
        //public void CreateUserEvent_ThrowsExceptionWhenAlreadyExistsInDeactivatedUsersList()
        //{
        //    //setup
        //    var state = new OrganizationGrainState();
        //    var userId = new UserId(Guid.NewGuid());
        //    state.Apply(new CreateUserEvent(userId));
        //    state.Apply(new DeactivateUserEvent(userId));

        //    //test
        //    Assert.Throws<UserIdIsAlreadyDeactivatedException>(() => state.Apply(new CreateUserEvent(userId)));
        //}
        //[Test]
        //public void CreateUserEvent_ThrowsExceptionUserIdNotSetInContext()
        //{
        //    SetEmptyPrincipal();
        //    var state = new OrganizationGrainState();
        //    Assert.Throws<UserIdIsNotSetInRequestContextException>(() => state.Apply(new CreateUserEvent(new UserId(Guid.NewGuid()))));
        //}
        //[Test]
        //public void DeactivateUserEvent_UserIdGetsAddedToDeactivatedUserIdsList()
        //{
        //    //setup
        //    var state = new OrganizationGrainState();
        //    var userId = new UserId(Guid.NewGuid());
        //    state.Apply(new CreateUserEvent(userId));
        //    state.Apply(new DeactivateUserEvent(userId));

        //    //test
        //    Assert.That(state.DeactivatedUserIds.Contains(userId));
        //}
        //[Test]
        //public void DeactivateUserEvent_UserIdIsntInActiveUserIdsList()
        //{
        //    //setup
        //    var state = new OrganizationGrainState();
        //    var userId = new UserId(Guid.NewGuid());
        //    state.Apply(new CreateUserEvent(userId));
        //    state.Apply(new DeactivateUserEvent(userId));

        //    //test
        //    Assert.That(state.ActiveUserIds.Contains(userId) is false);
        //}
        //[Test]
        //public void DeactivateUserEvent_ThrowsExceptionUserIdNotSetInContext()
        //{
        //    SetEmptyPrincipal();
        //    var state = new OrganizationGrainState();
        //    Assert.Throws<UserIdIsNotSetInRequestContextException>(() => state.Apply(new DeactivateUserEvent(new UserId(Guid.NewGuid()))));
        //}
        //[Test]
        //public void AddCustomDomainEvent_ThrowsExceptionUserIdNotSetInContext()
        //{
        //    SetEmptyPrincipal();
        //    var state = new OrganizationGrainState();
        //    Assert.Throws<UserIdIsNotSetInRequestContextException>(() => state.Apply(new AddCustomDomainEvent(new ValueObjects.CustomDomains.Domain("test.com"))));
        //}
        //[Test]
        //public void AddCustomDomainEvent_AddsToCustomDomainsList()
        //{
        //    //setup
        //    var state = new OrganizationGrainState();
        //    var domain = new ValueObjects.CustomDomains.Domain("test.com");

        //    //test
        //    state.Apply(new AddCustomDomainEvent(domain));
        //    Assert.That(state.CustomDomains.Contains(domain));
        //}
        //[Test]
        //public void RemoveCustomDomainEvent_ThrowsExceptionUserIdNotSetInContext()
        //{
        //    SetEmptyPrincipal();
        //    var state = new OrganizationGrainState();
        //    Assert.Throws<UserIdIsNotSetInRequestContextException>(() => state.Apply(new RemoveCustomDomainEvent(new ValueObjects.CustomDomains.Domain("test.com"))));
        //}
        //[Test]
        //public void RemoveCustomDomainEvent_RemovesFromCustomDomainsList()
        //{
        //    //setup
        //    var state = new OrganizationGrainState();
        //    var domain = new ValueObjects.CustomDomains.Domain("test.com");
        //    state.Apply(new AddCustomDomainEvent(domain));

        //    //test
        //    state.Apply(new RemoveCustomDomainEvent(domain));
        //    Assert.That(state.CustomDomains.Contains(domain) is false);
        //}
        //[Test]
        //public void RemoveCustomDomainEvent_ThrowsExceptionCustomDomainIsntAdded()
        //{
        //    //setup
        //    var state = new OrganizationGrainState();
        //    var domain = new ValueObjects.CustomDomains.Domain("test.com");

        //    //test
        //    Assert.Throws<CustomDomainIsntAddedException>(() => state.Apply(new RemoveCustomDomainEvent(domain)));
        //}




    }
}
