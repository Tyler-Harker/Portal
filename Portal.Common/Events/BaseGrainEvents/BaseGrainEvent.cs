﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Events.BaseGrainEvents
{
    public abstract class BaseGrainEvent : BaseEvent, IBaseGrainEvent
    {
    }
}
