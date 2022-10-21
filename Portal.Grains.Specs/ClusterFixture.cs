using Orleans.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Grains.Specs
{
    public class ClusterFixture : IDisposable
    {
        private sealed class Configurator : ISiloBuilderConfigurator
        {
            public void Configure(ISiloHostBuilder hostBuilder)
            {
                hostBuilder.AddMemoryGrainStorageAsDefault();
                hostBuilder.ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(OrganizationGrain).Assembly).WithReferences());
            }
        }

        public TestCluster Cluster { get; private set; }

        public ClusterFixture()
        {
            var builder = new TestClusterBuilder();
            builder.AddSiloBuilderConfigurator<Configurator>();
            this.Cluster = builder.Build();
            this.Cluster.Deploy();
        }

        public void Dispose()
        {
            this.Cluster.StopAllSilos();
        }
    }
}
