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

        Task<Page<IUserGrain>> GetActiveUsers(SkipTake skipTake);
        Task<Page<IUserGrain>> GetDeactivatedUsers(SkipTake skipTake);
        Task<Page<ICustomDomainGrain>> GetCustomDomains(SkipTake skipTake);
    }
}
