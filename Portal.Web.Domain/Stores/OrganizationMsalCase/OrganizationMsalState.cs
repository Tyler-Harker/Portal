using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.OrganizationMsalCase
{
    public record OrganizationMsalState(bool IsLoading, string? ErrorMessage) : BaseState(IsLoading, ErrorMessage);
}
