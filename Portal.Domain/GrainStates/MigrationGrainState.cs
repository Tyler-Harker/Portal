using Portal.Domain.Events.Migrations;
using Portal.Domain.ValueObjects.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.GrainStates
{
    public class MigrationGrainState : BaseState<IMigrationEvent>
    {
        public HashSet<MigrationId> AppliedMigrations { get; } = new HashSet<MigrationId>();

        public void Apply(MigrationAppliedEvent @event) => Apply(@event, () =>
        {
            AppliedMigrations.Add(@event.Id);
        });
    }
}
