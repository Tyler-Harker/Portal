using Portal.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common
{
    public class BaseState<TId> : BaseState
    {
        public TId? Id { get; set; }
    }
    public class BaseState
    {
        public CreatedById? CreatedById { get; set; }
        public CreatedByImpersonatorId? CreatedByImpersonatorId { get; set; }
        public CreatedAt? CreatedAt { get; set; }
        public LastUpdatedById? LastUpdatedById { get; set; }
        public LastUpdatedByImpersonatorId? LastUpdatedByImpersonatorId { get; set; }
        public LastUpdatedAt? LastUpdatedAt { get; set; }
        public IsActive? IsActive { get; set; }
    }
}
