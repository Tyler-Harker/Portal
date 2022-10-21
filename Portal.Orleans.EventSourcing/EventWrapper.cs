using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Orleans.EventSourcing
{
    public class EventWrapper<TEvent, TGrainId>
        where TEvent : IEvent
    {
        public EventWrapper(TEvent content, TGrainId grainId, DateTime timestamp, IPrincipal principal)
        {
            GrainId = grainId;
            Timestamp = timestamp;
            Principal = principal;
            Content = content;
        }
        public TGrainId GrainId { get; }

        public DateTime Timestamp { get; }

        public IPrincipal Principal { get; set; }
        public Dictionary<string, object> Headers { get; } = new Dictionary<string, object>();

        public TEvent Content { get; }

        public TEvent GetContent() => this.Content;

        public static EventWrapper<TEvent, TGrainId> Wrap(TEvent eventContent, TGrainId grainId, DateTime timestamp, IPrincipal principal) =>
            Activator.CreateInstance(typeof(EventWrapper<TEvent, TGrainId>), eventContent, grainId, timestamp, principal) as EventWrapper<TEvent, TGrainId>;
    }
}
