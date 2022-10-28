using Orleans;
using Orleans.Runtime;
using Portal.Domain.Constants;
using Portal.Domain.Events.Migrations;
using Portal.Domain.GrainStates;
using Portal.Domain.ValueObjects.Migrations;
using Portal.Grains.Interfaces.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains
{
    public class MigrationGrain : Grain<MigrationGrainState>, IMigrationGrain
    {
        public async Task Apply(IMigration migration)
        {
            Portal.Domain.Extensions.RequestContextExtensions.SetPrincipal(new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(CustomClaimTypes.UserId, Guid.Empty.ToString())
            })));
            if (State.AppliedMigrations.Contains(migration.Id) is false)
            {
                await migration.Action.AsyncAction(GrainFactory);
                State.Apply(new MigrationAppliedEvent(migration.Id));
                await WriteStateAsync();
            }
        }
    }
}
