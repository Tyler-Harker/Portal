using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Security;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Responses.Organizations
{
    public record GetOrganizationMsalConfigurationResponse(Authority Authority, ClientId ClientId);
    public record GetOrganizationByIdResponse(OrganizationId Id, OrganizationName Name, OrganizationShortName ShortName);
    public record GetOrganizationRolesByIdResponse(SkipTake SkipTake, List<Role> Results, int TotalRecords) : Page<Role>(SkipTake, Results, TotalRecords);
    public record GetOrganizationUsersByIdResponse(SkipTake SkipTake, List<UserTableData> Results, int TotalRecord) : Page<UserTableData>(SkipTake, Results, TotalRecord);
}
