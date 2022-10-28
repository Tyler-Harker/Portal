using MediatR;
using Microsoft.AspNetCore.Http;
using Orleans;
using Portal.Domain.Requests;
using Portal.Domain.Requests.Organizations;
using Portal.Domain.Responses.Organizations;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Grains.Interfaces.Public.Extensions;

namespace Portal.WebApi.RequestHandlers
{
    public class GetOrganizationMsalConfigurationHandler : IRequestHandler<GetOrganizationMsalConfigurationRequest, IResult>
    {
        private readonly Lazy<IClusterClient> _clusterClient;
        public GetOrganizationMsalConfigurationHandler(Lazy<IClusterClient> clusterClient)
        {
            _clusterClient = clusterClient;
        }
        public async Task<IResult> Handle(GetOrganizationMsalConfigurationRequest request, CancellationToken cancellationToken)
        {
            var organizationGrain = _clusterClient.Value.GetGrain(request.Id);
            var msalConfiguration = await organizationGrain.GetMsalConfiguration();
            if (msalConfiguration is not null)
            {
                return Results.Ok(new GetOrganizationMsalConfigurationResponse(msalConfiguration.Authority, msalConfiguration.Id));
            }
            else
            {
                return Results.NotFound();
            }
        }
    }
}
