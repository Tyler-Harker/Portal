using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Users;
using Portal.Domain.ValueObjects.CustomDomains;
using Portal.Domain.GrainStates;
using Portal.Domain.Responses.Organizations;
using Portal.Domain.ValueObjects.Security;
using Portal.Domain.ValueObjects.Modules;

namespace Portal.Grains.Interfaces.Public
{
    public interface IOrganizationGrain : IGrainWithGuidKey
    {
        Task<OrganizationId?> GetOrganizationId();
        Task<IUserGrain?> CreateUser(Username username, FirstName firstName, LastName lastName);
        Task DeactivateUser(UserId userId);
        Task ReactivateUser(UserId userId);
        Task<bool> IsUserActive(UserId userId);
        Task<OrganizationMsalConfiguration?> GetMsalConfiguration();
        Task SetMsalConfiguration(OrganizationMsalConfiguration msalConfiguration);

        Task<Page<IUserGrain>?> GetActiveUsers(SkipTake skipTake);
        Task<Page<IUserGrain>?> GetDeactivatedUsers(SkipTake skipTake);
        Task<Page<ICustomDomainGrain>> GetCustomDomains(SkipTake skipTake);
        Task<OrganizationTableData> GetTableData();
        Task<GetOrganizationByIdResponse> GetByIdRequest();
        Task<Page<Role>?> GetRoles(SkipTake skipTake);
        Task CreateRole(RoleName Name, HashSet<Privilege> Privileges);
        Task<bool> AddModule(ModuleName ModuleName);
        Task<bool> RemoveModule(ModuleName ModuleName);
    }
}
