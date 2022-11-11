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
using Portal.Domain.Responses.Organizations;
using Portal.Domain.ValueObjects.Security;
using Portal.Domain.ValueObjects.Modules;

namespace Portal.Grains
{
    public class OrganizationGrain : Grain<OrganizationGrainState>, Interfaces.Internal.IOrganizationGrain
    {
        private readonly ILogger _logger;
        public OrganizationGrain(ILogger<OrganizationGrain> logger)
        {
            _logger = logger;
        }

        public async Task<bool> AddModule(ModuleName ModuleName)
        {
            if(State.Modules.Contains(ModuleName))
            {
                return false;
            }
            State.Apply(new OrganizationModuleAdded(ModuleName));
            await WriteStateAsync();
            return true;
        }

        public async Task<bool> Create(OrganizationId id, OrganizationName name, OrganizationShortName shortName)
        {
            if(State.Id is null)
            {
                State.Apply(new OrganizationCreatedEvent(id, name, shortName));

                /* Add Default Roles */
                await CreateRole(new RoleName("Admin"), new HashSet<Privilege> { });
                await CreateRole(new RoleName("User"), new HashSet<Privilege> { });
                await WriteStateAsync();
                return true;
            }

            return false;
        }

        public async Task CreateRole(RoleName Name, HashSet<Privilege> Privileges)
        {
            if(State.Id is null)
            {
                return;
            }
            State.Apply(new RoleCreatedEvent(new Role(Name,Privileges)));
            await WriteStateAsync();
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

        public async Task<Page<IUserGrain>?> GetActiveUsers(SkipTake skipTake)
        {
            if(State.IsActive == new IsActive(false))
            {
                return null;
            }
            var activeUsers = State.ActiveUserIds
                .Skip(skipTake.Skip)
                .Take(skipTake.Take)
                .Select(x => GrainFactory.GetGrain(x))
                .ToList();

            return new Page<IUserGrain>(skipTake, activeUsers, State.ActiveUserIds.Count);
        }

        public Task<GetOrganizationByIdResponse?> GetByIdRequest()
        {
            if(State.IsActive == new IsActive(true))
            {
                return Task.FromResult(new GetOrganizationByIdResponse(State.Id, State.Name, State.ShortName));
            }
            else
            {
                return Task.FromResult((GetOrganizationByIdResponse?)null);
            }
        }

        public Task<Page<ICustomDomainGrain>> GetCustomDomains(SkipTake skipTake)
        {
            var domains = State.CustomDomains
                .Skip(skipTake.Skip)
                .Take(skipTake.Take)
                .Select(x => GrainFactory.GetGrain(x))
                .ToList();

            return Task.FromResult(new Page<ICustomDomainGrain>(skipTake, domains, State.CustomDomains.Count));
        }

        public Task<Page<IUserGrain>?> GetDeactivatedUsers(SkipTake skipTake)
        {
            var deactivatedUsers = State.ActiveUserIds
                .Skip(skipTake.Skip)
                .Take(skipTake.Take)
                .Select(x => GrainFactory.GetGrain(x))
                .ToList();

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

        public async Task<Page<Role>?> GetRoles(SkipTake skipTake)
        {
            if(State.IsActive == new IsActive(false))
            {
                return null;
            }
            return new Page<Role>(
                skipTake, 
                State.Roles
                    .Skip(skipTake.Skip)
                    .Take(skipTake.Take)
                    .Select(x => x.Value)
                    .ToList(),
                State.Roles.Count);
        }

        public Task<OrganizationTableData> GetTableData()
        {
            return Task.FromResult(new OrganizationTableData(State.Id, State.ShortName, State.Name, State.IsActive));
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

        public async Task<bool> RemoveModule(ModuleName ModuleName)
        {
            if (!State.Modules.Contains(ModuleName))
            {
                return false;
            }

            State.Apply(new OrganizationModuleRemoved(ModuleName));
            await WriteStateAsync();
            return true;
        }

        public Task SetMsalConfiguration(OrganizationMsalConfiguration msalConfiguration)
        {
            State.Apply(new OrganizationMsalConfigurationSetEvent(msalConfiguration.Authority, msalConfiguration.Id, msalConfiguration.Secret));
            return Task.FromResult(WriteStateAsync());
        }
    }
}
