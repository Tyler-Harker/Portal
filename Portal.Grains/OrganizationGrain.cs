using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.EventSourcing;
using Orleans.Providers;
using Orleans.Runtime;
using Portal.Domain.GrainStates;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Users;
using Portal.Grains.Interfaces.Public;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Grains.Interfaces.Internal.Extensions;
using Portal.Grains.Interfaces.Public.Extensions;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.Events.Organizations;

namespace Portal.Grains
{
    public class OrganizationGrain : Grain<OrganizationGrainState>, Interfaces.Internal.IOrganizationGrain
    {
        private readonly ILogger _logger;
        public OrganizationGrain(ILogger<OrganizationGrain> logger)
        {
            _logger = logger;
        }

        public Task<Interfaces.Internal.IOrganizationGrain> Create(OrganizationId id, OrganizationName name)
        {
            State.Apply(new CreateEvent(id, name));
            throw new NotImplementedException();
        }

        public async Task<IUserGrain> CreateUser(Username username, FirstName firstName, LastName lastName)
        {
            var newUserId = new UserId(Guid.NewGuid());
            var userGrain = GrainFactory.GetInternalGrain(newUserId);
            
            await userGrain.Create(newUserId, username, firstName, lastName);
            State.Apply(new CreateUserEvent(newUserId));
            return userGrain;
        }

        public Task<Page<IUserGrain>> GetActiveUsers(SkipTake skipTake)
        {
            var activeUsers = State.ActiveUserIds
                .Skip(skipTake.Skip)
                .Take(skipTake.Take)
                .Select(x => GrainFactory.GetGrain(x))
                .ToList()
                .AsReadOnly();

            return Task.FromResult(new Page<IUserGrain>(skipTake, activeUsers, State.ActiveUserIds.Count));
        }

        public Task<Page<ICustomDomainGrain>> GetCustomDomains(SkipTake skipTake)
        {
            var domains = State.CustomDomains
                .Skip(skipTake.Skip)
                .Take(skipTake.Take)
                .Select(x => GrainFactory.GetGrain(x))
                .ToList()
                .AsReadOnly();

            return Task.FromResult(new Page<ICustomDomainGrain>(skipTake, domains, State.CustomDomains.Count));
        }

        public Task<Page<IUserGrain>> GetDeactivatedUsers(SkipTake skipTake)
        {
            var deactivatedUsers = State.ActiveUserIds
                .Skip(skipTake.Skip)
                .Take(skipTake.Take)
                .Select(x => GrainFactory.GetGrain(x))
                .ToList()
                .AsReadOnly();

            return Task.FromResult(new Page<IUserGrain>(skipTake, deactivatedUsers, State.DeactivatedUserIds.Count));
        }

        public Task<bool> IsUserActive(UserId userId)
        {
            return Task.FromResult(State.ActiveUserIds.Contains(userId));
        }
    }
}
