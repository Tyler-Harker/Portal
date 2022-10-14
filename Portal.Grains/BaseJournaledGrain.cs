using Orleans.EventSourcing;
using Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains
{
    public abstract class BaseJournaledGrain<TState> : JournaledGrain<TState> where TState is BaseState
    {
    }
}
