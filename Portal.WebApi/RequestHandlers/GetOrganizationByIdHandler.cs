using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using Portal.Domain.Requests.Organizations;
using Portal.Domain.ValueObjects.Organizations;

namespace Portal.WebApi.RequestHandlers
{
    public class GetOrganizationByIdHandler : IRequestHandler<GetOrganizationByIdRequest, object>
    {
        private readonly Lazy<IClusterClient> _clusterClient;
        public GetOrganizationByIdHandler(Lazy<IClusterClient> clusterClient)
        {
            _clusterClient = clusterClient;
        }
        public async Task<object> Handle(GetOrganizationByIdRequest request, CancellationToken cancellationToken)
        {
            var organizationGrain = _clusterClient.Value.GetGrain(request.Id);
            var response = await organizationGrain.GetByIdRequest();
            if(response is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(response);
        }
    }
}
