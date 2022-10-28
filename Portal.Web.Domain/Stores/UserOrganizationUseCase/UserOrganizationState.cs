using Fluxor;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.UserOrganizationUseCase
{
    public record UserOrganizationState(
        OrganizationId? OrganizationId = null, 
        Portal.Domain.ValueObjects.CustomDomains.Domain? Domain = null, 
        bool IsLoading = false, string? 
        ErrorMessage = null
    ) : BaseState(IsLoading, ErrorMessage);
}
