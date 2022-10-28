using Newtonsoft.Json;
using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.UnitTests.ValueObjects
{
    [TestFixture]
    public class OrganizationIdTests
    {
        public void CanSerializeAndDeserializeObject()
        {
            var guid = Guid.NewGuid();
            var orgId = new OrganizationId(guid);
            var json = JsonConvert.SerializeObject(orgId);

        }
    }
}
