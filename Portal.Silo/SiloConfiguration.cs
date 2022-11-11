using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portal.Silo
{
    public class SiloConfiguration
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public string WEBSITE_PRIVATE_PORTS { get; set; }
        public int SiloPort => WEBSITE_PRIVATE_PORTS is null ? 0 : int.Parse(WEBSITE_PRIVATE_PORTS.Split(',')[0]);
        public int GatewayPort => WEBSITE_PRIVATE_PORTS is null ? 0 : int.Parse(WEBSITE_PRIVATE_PORTS.Split(',')[1]);
    }
    public class ConnectionStrings
    {
        public string AzureStorage { get; set; }
    }
}
