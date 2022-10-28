using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.ValueObjects
{
    public interface ISingleValueObject { }
    public interface ISingleValueObject<TType> : ISingleValueObject
    {
        TType Value { get; }
    }
}
