using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.ValueObjects.Migrations
{
    public interface IMigration
    {
        MigrationId Id { get; }
        MigrationAction Action { get; }
    }
    public record MigrationGrainId();
    public record MigrationId(Type Value) : ISingleValueObject<Type>;
    public record MigrationAction(Func<IGrainFactory, Task> Action)
    {
        public async Task AsyncAction(IGrainFactory Factory)
        {
            await Action(Factory);
        }
    }

}
