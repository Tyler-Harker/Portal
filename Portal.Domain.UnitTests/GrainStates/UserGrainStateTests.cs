using Portal.Domain.Events.Users;
using Portal.Domain.GrainStates;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.UnitTests.GrainStates
{
    [TestFixture]
    public class UserGrainStateTests : BaseStateTest
    {
        [Test]
        public void UserCreatedEvent_SetsOrganizationId()
        {
            //setup
            var state = new UserGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var userId = new UserId(Guid.NewGuid());
            var username = new Username(new Email("test@test.com"));
            var firstName = new FirstName("tyler");
            var lastName = new LastName("harker");

            //test
            state.Apply(new UserCreatedEvent(organizationId, userId, username, firstName, lastName));
            Assert.That(organizationId, Is.EqualTo(state.OrganizationId));
        }
        [Test]
        public void UserCreatedEvent_SetsUserId()
        {
            //setup
            var state = new UserGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var userId = new UserId(Guid.NewGuid());
            var username = new Username(new Email("test@test.com"));
            var firstName = new FirstName("tyler");
            var lastName = new LastName("harker");

            //test
            state.Apply(new UserCreatedEvent(organizationId, userId, username, firstName, lastName));
            Assert.That(userId, Is.EqualTo(state.Id));
        }
        [Test]
        public void UserCreatedEvent_SetsUsername()
        {
            //setup
            var state = new UserGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var userId = new UserId(Guid.NewGuid());
            var username = new Username(new Email("test@test.com"));
            var firstName = new FirstName("tyler");
            var lastName = new LastName("harker");

            //test
            state.Apply(new UserCreatedEvent(organizationId, userId, username, firstName, lastName));
            Assert.That(username, Is.EqualTo(state.Username));
        }
        [Test]
        public void UserCreatedEvent_SetsFirstName()
        {
            //setup
            var state = new UserGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var userId = new UserId(Guid.NewGuid());
            var username = new Username(new Email("test@test.com"));
            var firstName = new FirstName("tyler");
            var lastName = new LastName("harker");

            //test
            state.Apply(new UserCreatedEvent(organizationId, userId, username, firstName, lastName));
            Assert.That(firstName, Is.EqualTo(state.FirstName));
        }
        [Test]
        public void UserCreatedEvent_SetsLastName()
        {
            //setup
            var state = new UserGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var userId = new UserId(Guid.NewGuid());
            var username = new Username(new Email("test@test.com"));
            var firstName = new FirstName("tyler");
            var lastName = new LastName("harker");

            //test
            state.Apply(new UserCreatedEvent(organizationId, userId, username, firstName, lastName));
            Assert.That(lastName, Is.EqualTo(state.LastName));
        }
        [Test]
        public void UserCreatedEvent_SetsIsActiveTrue()
        {
            //setup
            var state = new UserGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var userId = new UserId(Guid.NewGuid());
            var username = new Username(new Email("test@test.com"));
            var firstName = new FirstName("tyler");
            var lastName = new LastName("harker");

            //test
            state.Apply(new UserCreatedEvent(organizationId, userId, username, firstName, lastName));
            Assert.That(state.IsActive, Is.EqualTo(new IsActive(true)));
        }
        [Test]
        public void UserDeactivedEvent_IsActiveFalse()
        {
            //setup
            var state = new UserGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var userId = new UserId(Guid.NewGuid());
            var username = new Username(new Email("test@test.com"));
            var firstName = new FirstName("tyler");
            var lastName = new LastName("harker");
            state.Apply(new UserCreatedEvent(organizationId, userId, username, firstName, lastName));


            //test
            state.Apply(new UserDeactivatedEvent());
            Assert.That(state.IsActive, Is.EqualTo(new IsActive(false)));
        }
        [Test]
        public void UserReactivedEvent_IsActiveTrue()
        {
            //setup
            var state = new UserGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var userId = new UserId(Guid.NewGuid());
            var username = new Username(new Email("test@test.com"));
            var firstName = new FirstName("tyler");
            var lastName = new LastName("harker");
            state.Apply(new UserCreatedEvent(organizationId, userId, username, firstName, lastName));
            state.Apply(new UserDeactivatedEvent());



            //test
            state.Apply(new UserReactivatedEvent());
            Assert.That(state.IsActive, Is.EqualTo(new IsActive(true)));
        }
    }
}
