using Orleans;
using Portal.Domain.ValueObjects.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains.Interfaces.Internal
{
    public interface IMigrationGrain : IGrainWithIntegerKey
    {
        public Task Apply(IMigration migration);
    }
}
