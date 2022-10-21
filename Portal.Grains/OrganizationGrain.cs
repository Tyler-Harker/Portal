using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.EventSourcing;
using Orleans.Providers;
using Orleans.Runtime;
using Portal.Common.Events.OrganizationEvents;
using Portal.Common.GrainStates;
using Portal.Common.ValueObjects.Organizations;
using Portal.Common.ValueObjects.Users;
using Portal.Domain.GrainStates;
using Portal.Domain.ValueObjects;
using Portal.Grains.Interfaces.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains
{
    public class OrganizationGrain : Grain<OrganizationGrainState>, IOrganizationGrain
    {
        private readonly ILogger _logger;
        public OrganizationGrain(ILogger<OrganizationGrain> logger)
        {
            _logger = logger;
        }

        public Task<Page<Domain.ValueObjects.Users.Id>> GetActiveUsers(SkipTake skipTake)
        {
            return State.ActiveUserIds.
            throw new NotImplementedException();
        }

        public Task<Page<Domain.ValueObjects.CustomDomains.Domain>> GetCustomDomains(SkipTake skipTake)
        {
            throw new NotImplementedException();
        }

        public Task<Page<Domain.ValueObjects.Users.Id>> GetDeactivatedUsers(SkipTake skipTake)
        {
            throw new NotImplementedException();
        }
    }
}
