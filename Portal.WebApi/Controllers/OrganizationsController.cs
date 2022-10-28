using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Domain.Requests;
using Portal.Domain.Requests.Organizations;
using Portal.Domain.ValueObjects.Organizations;

namespace Portal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrganizationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ShortName/{shortName}/DomainInformation")]
        public async Task<IResult> GetOrganizationDomainInformationByShortName([FromRoute]string shortName)
        {
             return await _mediator.Send(new GetOrganizationDomainInformationRequest(new OrganizationShortName(shortName)));
        }

    }
}
