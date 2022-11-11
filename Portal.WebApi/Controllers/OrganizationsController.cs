using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Domain.Requests;
using Portal.Domain.Requests.Organizations;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;

namespace Portal.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrganizationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpGet("ShortName/{shortName}/DomainInformation")]
        public async Task<object> GetOrganizationDomainInformationByShortName([FromRoute]string shortName)
        {
             return await _mediator.Send(new GetOrganizationDomainInformationRequest(new OrganizationShortName(shortName)));
        }

        [HttpGet("")]
        public async Task<object> GetOrganizations(int skip = 0, int take = 10, bool includeInactive = false)
        {
            return await _mediator.Send(new GetOrganizationsRequest(new SkipTake(skip, take), includeInactive));
        }

    }
}
