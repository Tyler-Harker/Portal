using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Exceptions.GrainExceptions
{
    public class GrainNotInitializedException : BaseException
    {
        public GrainNotInitializedException(Type grainType, object id) : base($"Grain of type {grainType.Name}, tried to execute action without being initialized with id: {id}")
        {
        }
    }
}
