using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Events.BaseGrainEvents
{
    public class InitializeStateEvent<TId> : BaseGrainEvent, IBaseGrainEvent
    {
        public InitializeStateEvent(TId id): base()
        {
            Id = id;
        }
        public TId Id { get; }
    }
}
