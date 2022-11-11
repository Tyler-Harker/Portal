using MediatR;
using Orleans;
using Portal.Domain.Requests.Organizations;
using Portal.Domain.Responses.Organizations;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;

namespace Portal.WebApi.RequestHandlers
{
    public class GetOrganizationsHandler : IRequestHandler<GetOrganizationsRequest, object>
    {
        private readonly Lazy<IClusterClient> _clusterClient;
        public GetOrganizationsHandler(Lazy<IClusterClient> clusterClient)
        {
            _clusterClient = clusterClient;
        }
        public async Task<object> Handle(GetOrganizationsRequest request, CancellationToken cancellationToken)
        {
            var organizationsGrain = _clusterClient.Value.GetGrain(new OrganizationsId());
            var organizationGrains = await organizationsGrain.GetActiveOrganizations(request.skipTake);

            var organizationResultsTask = organizationGrains.Results.Select(async grain =>
            {
                return await grain.GetTableData();
            });

            var organizationResults = await Task.WhenAll(organizationResultsTask);

            return Results.Ok(new Page<OrganizationTableData>(request.skipTake, organizationResults.ToList(), organizationGrains.TotalRecords));
        }
    }
}
