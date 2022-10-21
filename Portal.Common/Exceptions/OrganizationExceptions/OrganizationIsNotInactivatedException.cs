using Portal.Common.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Exceptions.OrganizationExceptions
{
    public class OrganizationIsNotInactivatedException : BaseException
    {
        public OrganizationIsNotInactivatedException(OrganizationId id) : base($"Organization with id: {id} is not inactivated")
        {
        }
    }
}
