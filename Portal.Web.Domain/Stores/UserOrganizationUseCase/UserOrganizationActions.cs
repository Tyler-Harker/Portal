using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain.Stores.UserOrganizationUseCase
{
    public interface IUserOrganizationAction
    {

    }
    public record LoadUserOrganization(OrganizationShortName ShortName) : IUserOrganizationAction;
    public record LoadUserOrganizationSuceeded(OrganizationId OrganizationId, Portal.Domain.ValueObjects.CustomDomains.Domain OrganizationDomain) : IUserOrganizationAction;
    public record LoadUserOrganizationFailed(string ErrorMessage) : IUserOrganizationAction;
}
