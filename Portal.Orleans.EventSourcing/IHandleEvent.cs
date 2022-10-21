using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Orleans.EventSourcing
{
    public interface IHandleEvent<TEvent, TGrainId>
        where TEvent : IEvent
    {
        Task On(EventWrapper<TEvent, TGrainId> envelope);
    }
}
