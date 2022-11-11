using Portal.Domain.Responses.Organizations;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationFormUseCase
{
    public record LoadOrganizationForm(OrganizationId Id);
    public record LoadOrganizationFormSucceded(GetOrganizationByIdResponse Response);
    public record LoadOrganizationFormFailed(string ErrorMessage);
}
