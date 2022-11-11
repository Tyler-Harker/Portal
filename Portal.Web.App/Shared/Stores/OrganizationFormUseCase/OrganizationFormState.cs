using Portal.Domain.Responses.Organizations;
using Portal.Web.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationFormUseCase
{
    public record OrganizationFormState(GetOrganizationByIdResponse? Model = null, bool IsLoading = false, string? ErrorMessage = null) : BaseState(IsLoading, ErrorMessage), IFormState<GetOrganizationByIdResponse>;
}
