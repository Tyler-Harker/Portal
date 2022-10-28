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

        public async Task<bool> Create(OrganizationId id, OrganizationName name, OrganizationShortName shortName)
        {
            if(State.Id is null)
            {
                State.Apply(new OrganizationCreatedEvent(id, name, shortName));
                await WriteStateAsync();
                return true;
            }

            return false;
        }

        public async Task<IUserGrain?> CreateUser(Username username, FirstName firstName, LastName lastName)
        {
            if(State.Id is not null)
            {
                var newUserId = new UserId(Guid.NewGuid());
                var userGrain = GrainFactory.GetInternalGrain(newUserId);
                if (await userGrain.Create(State.Id, newUserId, username, firstName, lastName))
                {
                    State.Apply(new ValidUserAddedEvent(newUserId));
                    await WriteStateAsync();
                    return userGrain;
                }
            }
            
            return null;
        }

        public async Task DeactivateUser(UserId userId)
        {
            if (State.ActiveUserIds.Contains(userId))
            {
                await GrainFactory.GetInternalGrain(userId).Deactivate();
                State.Apply(new UserDeactivatedEvent(userId));
                await WriteStateAsync();
            }
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

        public Task<OrganizationMsalConfiguration?> GetMsalConfiguration()
        {
            return Task.FromResult(State.MsalConfiguration);
        }

        public Task<OrganizationId?> GetOrganizationId()
        {
            return Task.FromResult(State.Id);
        }

        public Task<bool> IsUserActive(UserId userId)
        {
            return Task.FromResult(State.ActiveUserIds.Contains(userId));
        }

        public async Task ReactivateUser(UserId userId)
        {
            if (State.DeactivatedUserIds.Contains(userId))
            {
                await GrainFactory.GetInternalGrain(userId).Reactivate();
                State.Apply(new UserReactivatedEvent(userId));
                await WriteStateAsync();
            }
        }

        public Task SetMsalConfiguration(OrganizationMsalConfiguration msalConfiguration)
        {
            State.Apply(new OrganizationMsalConfigurationSetEvent(msalConfiguration.Authority, msalConfiguration.Id, msalConfiguration.Secret));
            return Task.FromResult(WriteStateAsync());
        }
    }
}
