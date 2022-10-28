using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Moq;
using Orleans.TestingHost;
using Orleans.TestKit;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Users;
using Portal.Grains.Interfaces.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains.UnitTests
{
    [TestFixture]
    public class OrganizationTests : BaseTest
    {
        [Test]
        public async Task Create_GetsCreated()
        {
            //setup
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin org");
            var organizationShortName = new OrganizationShortName("admin");
            var grain = await Silo.GetGrain(organizationId);

            //test
            Assert.That(await grain.Create(organizationId, organizationName, organizationShortName), Is.True);
        }

        [Test]
        public async Task Create_DoesntCreateBecauseAlreadyCreated()
        {
            //setup
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin org");
            var organizationShortName = new OrganizationShortName("admin");
            var grain = await Silo.GetGrain(organizationId);
            await grain.Create(organizationId, organizationName, organizationShortName);

            //test
            Assert.That(await grain.Create(organizationId, organizationName, organizationShortName), Is.False);
        }

        [Test]
        public async Task CreateUser_U()
        {
            //setup
            var organizationId = new OrganizationId(Guid.NewGuid());
            var organizationName = new OrganizationName("admin org");
            var organizationShortName = new OrganizationShortName("admin");
            var grain = await Silo.GetGrain(organizationId);
            await grain.Create(organizationId, organizationName, organizationShortName);

            var username = new Username(new Email("tyler@test.com"));
            var firstName = new FirstName("tyler");
            var lastName = new LastName("harker");

            //test
            Assert.NotNull(await grain.CreateUser(username, firstName, lastName));
        }
    }
}
