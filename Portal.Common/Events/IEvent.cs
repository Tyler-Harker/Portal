using Portal.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Events
{
    public interface IEvent
    {
        public CreatedAt CreatedAt { get; }
        public CreatedById CreatedById { get; }
        public CreatedByImpersonatorId? CreatedByImpersonatorId { get; }
    }
}
