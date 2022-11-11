using MediatR;
using Orleans;
using Portal.Domain.Requests.Organizations;
using Portal.Domain.Responses.Organizations;

namespace Portal.WebApi.RequestHandlers
{
    public class GetOrganizationUsersByIdHandler : IRequestHandler<GetOrganizationUsersByIdRequest, object>
    {
        private readonly Lazy<IClusterClient> _clusterClient;
        public GetOrganizationUsersByIdHandler(Lazy<IClusterClient> clusterClient)
        {
            _clusterClient = clusterClient;
        }
        public async Task<object> Handle(GetOrganizationUsersByIdRequest request, CancellationToken cancellationToken)
        {
            var organizationGrain = _clusterClient.Value.GetGrain(request.Id);

            var activeUserGrainsPage = await organizationGrain.GetActiveUsers(request.SkipTake);
            if(activeUserGrainsPage is null)
            {
                return Results.NotFound();
            }

            var userTableTasks = activeUserGrainsPage.Results.Select(async grain => await grain.GetTableData());

            var userTableResults = await Task.WhenAll(userTableTasks);


            return Results.Ok(new GetOrganizationUsersByIdResponse(activeUserGrainsPage.SkipTake, userTableResults.ToList(), activeUserGrainsPage.TotalRecords));
        }
    }
}
