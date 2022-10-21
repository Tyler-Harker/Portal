using Microsoft.Extensions.Logging;
using Orleans.EventSourcing;
using Orleans.Providers;
using Orleans.Runtime;
using Portal.Common.Events.OrganizationEvents;
using Portal.Common.GrainStates;
using Portal.Common.ValueObjects;
using Portal.Common.ValueObjects.Organizations;
using Portal.Common.ValueObjects.Users;
using Portal.GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains
{
    public class OrganizationGrain : BaseGrain<OrganizationState, OrganizationId>, IOrganizationGrain
    {
        private readonly ILogger _logger;
        public OrganizationGrain(ILogger<OrganizationGrain> logger)
        {
            _logger = logger;
        }

        protected override OrganizationId GrainId => new OrganizationId(this.IdentityString);

        public async Task Initialize(OrganizationName name) => await ExecuteAsync(async () =>
        {
            State.Apply(new InitializeEvent(GrainId, name));
        }, isInitialization: true);

        public async Task<IUserGrain> CreateUser() => await ExecuteAsync<IUserGrain>(async () =>
        {
            var userGrain = GrainFactory.GetGrain(new UserId(Guid.NewGuid()));
            return null;
        });

        public async Task<List<IUserGrain>> GetUsers(SkipTake skipTake) => await ExecuteAsync<List<IUserGrain>>(async () =>
        {
            return State.ActiveUserIds
                .Skip(skipTake.Skip)
                .Take(skipTake.Take)
                .Select(uId => GrainFactory.GetGrain(uId)).ToList();
        });
    }
}
