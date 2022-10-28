using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.UserUseCase
{
    public record SetUserOrganizationId(OrganizationId OrganizationId);
}
