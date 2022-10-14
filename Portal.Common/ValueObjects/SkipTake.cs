using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects
{
    public class SkipTake : BaseValueObject
    {
        public int Skip { get; protected set; }
        public int Take { get; protected set; }
        public SkipTake(int skip = 0, int take = 10) 
        {
            Skip = skip;
            Take = take;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Skip;
            yield return Take;
        }
    }
}
