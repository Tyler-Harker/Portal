using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using Portal.Domain.ValueObjects;

namespace Portal.Grains.Interfaces.Public
{
    public interface IOrganizationGrain : IGrainWithGuidKey
    {
        Task<Page<Domain.ValueObjects.Users.Id>> GetActiveUsers(SkipTake skipTake);
        Task<Page<Domain.ValueObjects.Users.Id>> GetDeactivatedUsers(SkipTake skipTake);
        Task<Page<Domain.ValueObjects.CustomDomains.Domain>> GetCustomDomains(SkipTake skipTake);
    }
}
