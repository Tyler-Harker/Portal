using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Exceptions.GrainExceptions
{
    public class GrainNotActiveException<TId> : BaseException
    {
        public GrainNotActiveException(Type type, TId id) : base($"Grain of type: {type.Name} with id: {id} is not active.")
        {
        }
    }
}
