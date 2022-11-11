using Portal.Domain.ValueObjects.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Constants
{
    public static class Modules
    {
        public readonly static Module[] List = new Module[]
        {
            AdminModule
        };
        public readonly static Module AdminModule = new Module(new ModuleName("Admin"), new ModulePrivilege[]
        {
            new ModulePrivilege("Organizations.List"),
            new ModulePrivilege("Organizations.Create"),
            new ModulePrivilege("Organizations.Reactivate"),
            new ModulePrivilege("Organizations.Deactivate")
        });


    }
}
