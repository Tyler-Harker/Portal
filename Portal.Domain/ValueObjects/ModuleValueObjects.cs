using Portal.Domain.ValueObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.ValueObjects.Modules
{
    public record Module(ModuleName Name, ModulePrivilege[] ModulePrivileges);
    public record ModuleName(string Value) : ISingleValueObject<string>;
    public record ModulePrivilege(string PrivilegeName) : PrivilegeName(PrivilegeName);
} 
