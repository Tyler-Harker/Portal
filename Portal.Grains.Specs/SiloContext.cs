using Orleans.TestKit;
using Portal.Common;
using Portal.Common.ValueObjects.Organizations;
using Portal.Common.ValueObjects.Users;
using Portal.GrainInterfaces;
using Portal.Grains.Specs.UnitTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains.Specs
{
    public class SiloContext
    {
        public readonly TestKitSilo Silo = new TestKitSilo();
        private readonly Dictionary<OrganizationsId, IOrganizationsGrain> _organizationsGrains = new Dictionary<OrganizationsId, IOrganizationsGrain>();
        private readonly Dictionary<OrganizationId, IOrganizationGrain> _organizationGrains = new Dictionary<OrganizationId, IOrganizationGrain>();
        private readonly Dictionary<UserId, IUserGrain> _userGrains = new Dictionary<UserId, IUserGrain>();
        private readonly Dictionary<TestGrainId, ITestBaseGrain> _testBaseGrains = new Dictionary<TestGrainId, ITestBaseGrain>();

        public async Task<IOrganizationsGrain> GetGrain(OrganizationsId id)
        {
            if (!_organizationsGrains.ContainsKey(id))
            {
                _organizationsGrains.Add(id, await this.Silo.CreateGrainAsync<OrganizationsGrain>(id.Value));
            }
            return _organizationsGrains[id];
        }

        public async Task<ITestBaseGrain> GetGrain(TestGrainId id)
        {
            if (!_testBaseGrains.ContainsKey(id))
            {
                _testBaseGrains.Add(id, await this.Silo.CreateGrainAsync<TestBaseGrain>(id.Value));
            }
            return _testBaseGrains[id];
        }

        public async Task<IOrganizationGrain> GetGrain(OrganizationId id)
        {
            if (!_organizationGrains.ContainsKey(id))
            {
                _organizationGrains.Add(id, await this.Silo.CreateGrainAsync<OrganizationGrain>(id.Value));
            }
            return _organizationGrains[id];
        }

        public async Task<IUserGrain> GetGrain(UserId id)
        {
            if (!_userGrains.ContainsKey(id))
            {
                _userGrains.Add(id, await this.Silo.CreateGrainAsync<UserGrain>(id.Value));
            }
            return _userGrains[id];
        }
    }
}
