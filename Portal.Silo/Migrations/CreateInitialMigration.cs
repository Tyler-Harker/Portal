using Portal.Domain.ValueObjects.Migrations;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Grains.Interfaces.Internal.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Silo.Migrations
{
    public record CreateInitialMigration : IMigration
    {
        public MigrationId Id => new MigrationId(typeof(CreateInitialMigration));

        public MigrationAction Action => new MigrationAction(async (grainFactory) =>
        {
            var organizationsGrain = grainFactory.GetInternalGrain(new OrganizationsId());
            var organizationGrain = await organizationsGrain.CreateOrganization(new OrganizationShortName("admin"), new OrganizationName("Admin Org"));
            await organizationGrain.SetMsalConfiguration(new OrganizationMsalConfiguration(new Authority("https://login.microsoftonline.com/a4aa9f35-9917-4518-b764-5fbbb893a6cd"), new ClientId("a99a8939-b2fd-4831-b8f2-f9db51cfbe88"), new ClientSecret("")));
        });
    }
}
