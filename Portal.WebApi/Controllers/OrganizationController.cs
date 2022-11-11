using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Grains.Interfaces.Public.Extensions;
using Orleans;
using Portal.Domain.ValueObjects.Organizations;
using Microsoft.OpenApi.Validations.Rules;
using MediatR;
using Portal.Domain.Requests.Organizations;
using Portal.Domain.ValueObjects;

namespace Portal.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrganizationController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpGet("{organizationId}/msalConfiguration")]
        public async Task<object> GetOrganizationMsalConfiguration([FromRoute] Guid organizationId)
        {
            return await _mediator.Send(new GetOrganizationMsalConfigurationRequest(new OrganizationId(organizationId)));
        }

        [HttpGet("{organizationId}")]
        public async Task<object> GetOrganizationById([FromRoute] Guid organizationId)
        {
            return await _mediator.Send(new GetOrganizationByIdRequest(new OrganizationId(organizationId)));
        }

        [HttpGet("{organizationId}/roles")]
        public async Task<object> GetOrganizationRolesById([FromRoute] Guid organizationId, int skip = 0, int take = 10)
        {
            return await _mediator.Send(new GetOrganizationRolesByIdRequest(new OrganizationId(organizationId), new SkipTake(skip, take)));
        }

        [HttpGet("{organizationId}/users")]
        public async Task<object> GetOrganizationUsers([FromRoute] Guid organizationId, int skip = 0, int take = 10)
        {
            return await _mediator.Send(new GetOrganizationUsersByIdRequest(new OrganizationId(organizationId), new SkipTake(skip, take)));
        }

    }
}
