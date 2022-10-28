using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Grains.Interfaces.Public.Extensions;
using Orleans;
using Portal.Domain.ValueObjects.Organizations;
using Microsoft.OpenApi.Validations.Rules;
using MediatR;
using Portal.Domain.Requests.Organizations;

namespace Portal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrganizationController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        [HttpGet("{organizationId}/msalConfiguration")]
        public async Task<IResult> GetOrganizationMsalConfiguration([FromRoute] Guid organizationId)
        {
            return await _mediator.Send(new GetOrganizationMsalConfigurationRequest(new OrganizationId(organizationId)));
        }

    }
}
