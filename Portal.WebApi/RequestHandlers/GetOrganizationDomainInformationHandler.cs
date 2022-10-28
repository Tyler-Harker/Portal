using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class GetOrganizationDomainInformationHandler : IRequestHandler<GetOrganizationDomainInformationRequest, IResult>
    {
        private readonly Lazy<IClusterClient> _clusterClient;
        public GetOrganizationDomainInformationHandler(Lazy<IClusterClient> clusterClient)
        {
            _clusterClient = clusterClient;
        }

        public async Task<IResult> Handle(GetOrganizationDomainInformationRequest request, CancellationToken cancellationToken)
        {
            var organizationsGrain = _clusterClient.Value.GetGrain(new OrganizationsId());
            var organizationGrain = await organizationsGrain.GetOrganization(request.ShortName);
            var organizationId = await organizationGrain.GetOrganizationId();
            return Results.Ok(new GetOrganizationDomainInformationResponse(organizationId, new Portal.Domain.ValueObjects.CustomDomains.Domain("admin.localhost")));
        }
    }
}
