using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Exceptions.GrainExceptions
{
    public class GrainAlreadyInitializedException<TId> : BaseException
    {
        public GrainAlreadyInitializedException(Type type, TId id) : base($"Grian with type: {type.Name}, with id: {id} has already been initialized.")
        {
        }
    }
}
