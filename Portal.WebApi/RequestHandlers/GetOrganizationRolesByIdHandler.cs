using MediatR;
using Orleans;
using Portal.Domain.Requests.Organizations;
using Portal.Domain.Responses.Organizations;

namespace Portal.WebApi.RequestHandlers
{
    public class GetOrganizationRolesByIdHandler : IRequestHandler<GetOrganizationRolesByIdRequest, object>
    {
        private readonly Lazy<IClusterClient> _clusterClient;
        public GetOrganizationRolesByIdHandler(Lazy<IClusterClient> clusterClient)
        {
            _clusterClient = clusterClient;
        }

        public async Task<object> Handle(GetOrganizationRolesByIdRequest request, CancellationToken cancellationToken)
        {
            var organizationGrain = _clusterClient.Value.GetGrain(request.Id);
            var rolesPage = await organizationGrain.GetRoles(request.SkipTake);
            if(rolesPage is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(new GetOrganizationRolesByIdResponse(rolesPage.SkipTake, rolesPage.Results, rolesPage.TotalRecords));
        }
    }
}
