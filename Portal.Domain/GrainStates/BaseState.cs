using Portal.Domain.Events;
using Portal.Domain.Exceptions;
using Portal.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.GrainStates
{
    public abstract class BaseState<TEvent>
        where TEvent : IEvent
    {
        public CreatedAt? CreatedAt { get; protected set; }
        public CreatedById? CreatedById { get; protected set; }
        public CreatedByImpersonatorId? CreatedByImpersonatorId { get; protected set; }
        public UpdatedAt? UpdatedAt { get; protected set; }
        public UpdatedById? UpdatedById { get; protected set; }
        public UpdatedByImpersonatorId? UpdatedByImpersonatorId { get; protected set; }
        public ICollection<TEvent> Events { get; private set; } = new List<TEvent>();
        public void Apply(TEvent @event, Action action)
        {
            if(@event.LoggedInUserId is null)
            {
                throw new UserIdIsNotSetInRequestContextException();
            }
            UpdatedAt = new UpdatedAt(@event.Time);
            UpdatedById = new UpdatedById(@event.LoggedInUserId);
            UpdatedByImpersonatorId = @event.ImpersonatorUserId is null ? null : new UpdatedByImpersonatorId(@event.ImpersonatorUserId);

            if(CreatedAt is null)
            {
                CreatedAt = new CreatedAt(UpdatedAt.Value);
                CreatedById = new CreatedById(UpdatedById.Value);
                CreatedByImpersonatorId = UpdatedById is null ? null : new CreatedByImpersonatorId(UpdatedById.Value);
            }
            action();
        }

    }
}
