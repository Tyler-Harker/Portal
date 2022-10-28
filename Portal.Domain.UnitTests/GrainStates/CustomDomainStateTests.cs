using Portal.Domain.Events.CustomDomains;
using Portal.Domain.GrainStates;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.UnitTests.GrainStates
{
    [TestFixture]
    public class CustomDomainStateTests : BaseStateTest
    {
        [Test]
        public void CustomDomainAddedEvent_DomainIsSet()
        {
            //setup
            var state = new CustomDomainGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var domain = new ValueObjects.CustomDomains.Domain("test.com");

            //test
            state.Apply(new CustomDomainAddedEvent(organizationId, domain));
            Assert.That(domain, Is.EqualTo(state.Domain));
        }

        [Test]
        public void CustomDomainAddedEvent_OrganizationIdIsSet()
        {
            //setup
            var state = new CustomDomainGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var domain = new ValueObjects.CustomDomains.Domain("test.com");

            //test
            state.Apply(new CustomDomainAddedEvent(organizationId, domain));
            Assert.That(organizationId, Is.EqualTo(state.OrganizationId));
        }

        [Test]
        public void CustomDomainRemovedEvent_OrganizationIdIsSetToNull()
        {
            //setup
            var state = new CustomDomainGrainState();
            var organizationId = new OrganizationId(Guid.NewGuid());
            var domain = new ValueObjects.CustomDomains.Domain("test.com");
            state.Apply(new CustomDomainAddedEvent(organizationId, domain));

            //test
            state.Apply(new CustomDomainRemovedEvent());
            Assert.That(state.OrganizationId, Is.Null);
        }

    }
}
