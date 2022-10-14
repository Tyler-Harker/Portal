using Microsoft.Extensions.Logging;
using Orleans.EventSourcing;
using Orleans.Providers;
using Orleans.Runtime;
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
    public class OrganizationGrain : JournaledGrain<OrganizationState>, IOrganizationGrain
    {
        private readonly ILogger _logger;
        public OrganizationGrain(ILogger<OrganizationGrain> logger)
        {
            _logger = logger;
        }

        public Task Create(OrganizationName name)
        {
            throw new NotImplementedException();
        }

        public Task<IUserGrain> CreateUser()
        {
            GrainFactory.GetGrain(new UserId(Guid.NewGuid()));
            throw new NotImplementedException();
        }

        public Task<List<IUserGrain>> GetUsers(SkipTake skipTake)
        {
            throw new NotImplementedException();
        }
    }
}
