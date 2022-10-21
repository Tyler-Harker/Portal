using Orleans.Runtime;
using Portal.Common.Events.BaseGrainEvents;
using Portal.Common.Exceptions.ContextExceptions;
using Portal.Common.Exceptions.GrainExceptions;
using Portal.Common.Extensions;
using Portal.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common
{
    public abstract class BaseState<TId> : BaseState
    {
        public TId? Id { get; protected set; }

        public void Apply(InitializeStateEvent<TId> @event)
        {
            if (Id is not null) throw new GrainAlreadyInitializedException<TId>(this.GetType(), Id);
            var loggedInUserId = RequestContextExtensions.GetLoggedInUserId();
            if (loggedInUserId is null) throw new UserIdNotSetInContextException();

            Id = @event.Id;
            IsActive = new IsActive(true);
            CreatedAt = @event.CreatedAt;
            LastUpdatedAt = new LastUpdatedAt(@event.CreatedAt.Value);
            CreatedById = new CreatedById(@event.CreatedById.Value);
            LastUpdatedById = new LastUpdatedById(@event.CreatedById.Value);
            CreatedByImpersonatorId = @event.CreatedByImpersonatorId is null ? null : new CreatedByImpersonatorId(@event.CreatedByImpersonatorId.Value);
            LastUpdatedByImpersonatorId = @event.CreatedByImpersonatorId is null ? null : new LastUpdatedByImpersonatorId(@event.CreatedByImpersonatorId.Value);
        }

        protected void Apply(ReActivateEvent @event) => Update(() =>
        {
            IsActive = new IsActive(true);
        });
        protected void Apply(DeactivateEvent @event) => Update(() =>
        {
            IsActive = new IsActive(false);
        });

        protected void Update(Action action, bool isReactivating = false)
        {
            if (Id is null) throw new GrainNotInitializedException(this.GetType(), Id);
            var loggedInUserId = RequestContextExtensions.GetLoggedInUserId();
            if (loggedInUserId is null) throw new UserIdNotSetInContextException();

            action();

            LastUpdatedAt = new LastUpdatedAt(DateTime.UtcNow);
            LastUpdatedById = new LastUpdatedById(loggedInUserId.Value);
            LastUpdatedByImpersonatorId = new LastUpdatedByImpersonatorId(loggedInUserId.Value);
        }
    }
    public abstract class BaseState
    {
        public CreatedById? CreatedById { get; protected set; }
        public CreatedByImpersonatorId? CreatedByImpersonatorId { get; protected set; }
        public CreatedAt? CreatedAt { get; protected set; }
        public LastUpdatedById? LastUpdatedById { get; protected set; }
        public LastUpdatedByImpersonatorId? LastUpdatedByImpersonatorId { get; protected set; }
        public LastUpdatedAt? LastUpdatedAt { get; protected set; }
        public IsActive? IsActive { get; protected set; } = new IsActive(true);

    }
}
