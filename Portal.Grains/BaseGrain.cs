//using Orleans;
//using Orleans.Runtime;
//using Portal.Common;
//using Portal.Common.Constants;
//using Portal.Common.Events;
//using Portal.Common.Events.BaseGrainEvents;
//using Portal.Common.Exceptions.GrainExceptions;
//using Portal.Common.Privileges;
//using Portal.GrainInterfaces;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Security.Principal;
//using System.Text;
//using System.Threading.Tasks;

//namespace Portal.Grains
//{
//    public abstract class BaseGrain<TState, TId> : Grain<TState>, IBaseGrain
//         where TState : BaseState<TId>, new()
//    {
//        protected IPrincipal Principal => (IPrincipal)RequestContext.Get(RequestContextConstants.IPrinciple);
//        protected abstract TId GrainId { get; }

        



//        protected async Task<TResponse> ExecuteAsync<TResponse>(Func<Task<TResponse>> action, bool isInitialization = false, bool isReActivation = false)
//        {
//            Validate(isInitialization, isReActivation);
//            return await action();
//        }

//        protected async Task ExecuteAsync(Func<Task> action, bool isInitialization = false, bool isReActivation = false)
//        {
//            Validate(isInitialization, isReActivation);
//            await action();
//        }

//        protected void Validate(bool isInitialization, bool isReActivation)
//        {
//            if (!isInitialization)
//            {
//                if (State.Id is null) throw new GrainNotInitializedException(this.GetType(), GrainId);
//            }
//            if (!isReActivation)
//            {
//                if (State.IsActive.Value == false) throw new GrainNotActiveException<TId>(this.GetType(), GrainId);
//            }
//        }

//        protected void Apply<TEvent>(TEvent @event)
//            where TEvent : IEvent
//        {
//            dynamic s = this.State;
//            s.Apply(@event);
//        }

//        public Task Deactivate() => ExecuteAsync(() =>
//        {
//            return Task.FromResult(() => Apply(new DeactivateEvent()));
//        });

//        public Task Reactivate() => ExecuteAsync(() =>
//        {
//            return Task.FromResult(() => Apply(new ReActivateEvent()));
//        }, isReActivation: true);

//        public Task<bool> IsActive()
//        {
//            return Task.FromResult(State.IsActive?.Value is true && State.Id is not null);
//        }
//    }
//}
