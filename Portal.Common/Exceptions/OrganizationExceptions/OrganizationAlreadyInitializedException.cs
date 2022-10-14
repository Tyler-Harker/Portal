using Portal.Common.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Exceptions.OrganizationExceptions
{
    public class OrganizationAlreadyInitializedException : BaseException
    {
        public OrganizationAlreadyInitializedException(OrganizationId id) : base($"Organization with id: {id} has already been initialized.")
        {
        }
    }
}
