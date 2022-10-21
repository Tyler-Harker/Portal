using NUnit.Framework;
using Portal.Common.Constants;
using Portal.Common.Exceptions.ContextExceptions;
using Portal.Common.Exceptions.GrainExceptions;
using Portal.Common.Exceptions.OrganizationExceptions;
using Portal.Common.Extensions;
using Portal.Common.ValueObjects.Organizations;
using Portal.Common.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains.Specs.UnitTests
{
    [TestFixture]
    public class OrganizationsGrainTests : BaseTest
    {
        [Test]
        public async Task BeforeInitialization_CreateOrganization_ThrowsException()
        {
            var grain = await Silo.GetGrain(new OrganizationsId("test"));
            var organizationId = new OrganizationId("admin");
            var organizationName = new OrganizationName("admin corp");

            Assert.ThrowsAsync<GrainNotInitializedException>(async () => await grain.CreateOrganization(organizationId, organizationName));
        }
        [Test]
        public async Task BeforeInitialization_DeactivateOrganization_ThrowsException()
        {
            var grain = await Silo.GetGrain(new OrganizationsId("test"));
            var organizationId = new OrganizationId("admin");

            Assert.ThrowsAsync<GrainNotInitializedException>(() => grain.DeactivateOrganization(organizationId));
        }
        [Test]
        public async Task BeforeInitialization_ReactivateOrganization_ThrowsException()
        {
            var grain = await Silo.GetGrain(new OrganizationsId("test"));
            var organizationId = new OrganizationId("admin");

            Assert.ThrowsAsync<GrainNotInitializedException>(() => grain.ReactivateOrganization(organizationId));
        }
        [Test]
        public async Task BeforeInitialization_GetActiveOrganizations_ThrowsException()
        {
            var grain = await Silo.GetGrain(new OrganizationsId("test"));

            Assert.ThrowsAsync<GrainNotInitializedException>(() => grain.GetActiveOrganizations());
        }

        [Test]
        public async Task AfterInitialization_CreateOrganization_NewOrganizationIsInActiveList()
        {
            //setup
            var grain = await Silo.GetGrain(new OrganizationsId("test"));
            await grain.Initialize();
            var organizationId = new OrganizationId("admin");
            var organizationName = new OrganizationName("admin corp");
            
            //test
            var organizationGrain = await grain.CreateOrganization(organizationId, organizationName);
            var activeOrganizationIds = await grain.GetActiveOrganizationIds();

            Assert.Contains(organizationId, activeOrganizationIds.ToList());
        }

        [Test]
        public async Task AfterInitialization_DeactivateOrganization_OrganizationNoLongerInActiveOrganizationIds()
        {
            //setup
            var grain = await Silo.GetGrain(new OrganizationsId("test"));
            await grain.Initialize();
            var organizationId = new OrganizationId("admin");
            var organizationName = new OrganizationName("admin corp");
            var organizationGrain = await grain.CreateOrganization(organizationId, organizationName);

            //test
            await grain.DeactivateOrganization(organizationId);
            var activeOrganizationIds = await grain.GetActiveOrganizationIds();
            Assert.IsFalse(activeOrganizationIds.Contains(organizationId));
        }
    }
}
