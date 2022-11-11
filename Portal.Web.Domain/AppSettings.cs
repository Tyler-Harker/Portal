using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.Domain
{
    public class AppSettings
    {
        public AppSettingsUrls Urls { get; set; }
    }
    public class AppSettingsUrls
    {
        public string Web { get; set; }
        public string App { get; set; }
        public string WebApi { get; set; }
    }
}
