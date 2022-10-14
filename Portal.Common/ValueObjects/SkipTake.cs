using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.ValueObjects
{
    public class SkipTake : BaseValueObject
    {
        public uint Skip { get; protected set; }
        public uint Take { get; protected set; }
        public SkipTake(uint skip = 0, uint take = 10) 
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
