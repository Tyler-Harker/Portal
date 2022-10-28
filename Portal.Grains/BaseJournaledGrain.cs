//using Orleans;
//using Orleans.EventSourcing;
//using Orleans.Runtime;
//using Portal.Common;
//using Portal.Common.Events;
//using Portal.Common.Exceptions.GrainExceptions;
//using Portal.Common.ValueObjects;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Portal.Grains
//{
//    public abstract class BaseJournaledGrain<TState, TId> : JournaledGrain<TState> 
//        where TState : BaseState<TId>, new() 
//    {
//        protected abstract TId GrainId { get; }

//        protected async Task<TResponse> ExecuteAsync<TResponse>(Func<Task<TResponse>> action, bool isInitialization = false, bool isReActivation = false)
//        {
//            await ValidateState(isInitialization, isReActivation);
//            return await action();
//        }

//        protected async Task ExecuteAsync(Func<Task> action, bool isInitialization = false, bool isReActivation = false)
//        {
//            await ValidateState(isInitialization, isReActivation);
//            await action();
//        }

//        protected async Task ValidateState(bool isInitialization = false, bool isReActivation = false)
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
//    }
//}
