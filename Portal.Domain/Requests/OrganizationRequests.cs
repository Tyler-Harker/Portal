using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Requests.Organizations
{
    public record GetOrganizationMsalConfigurationRequest(OrganizationId Id) : IHttpRequest;
    public record GetOrganizationByIdRequest(OrganizationId Id) : IHttpRequest;
    public record GetOrganizationRolesByIdRequest(OrganizationId Id, SkipTake SkipTake) : IHttpRequest;
    public record GetOrganizationUsersByIdRequest(OrganizationId Id, SkipTake SkipTake) : IHttpRequest;
}
