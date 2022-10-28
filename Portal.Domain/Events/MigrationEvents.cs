using Portal.Domain.ValueObjects.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Events.Migrations
{
    public interface IMigrationEvent : IEvent { }

    public record MigrationAppliedEvent(MigrationId Id) : BaseEvent, IMigrationEvent;
}
