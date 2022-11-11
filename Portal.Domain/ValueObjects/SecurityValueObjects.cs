using Portal.Domain.ValueObjects.Organizations;
using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.ValueObjects.Security
{
    public record Role(RoleName Name, HashSet<Privilege> Privileges);
    public record RoleName(string Value) : ISingleValueObject<string> { }
    public record Privilege(PrivilegeName Name, OrganizationId OrganizationId);
    public record PrivilegeName(string Value) : ISingleValueObject<string> { }
    public record PrivilegeSubject(OrganizationId? OrganizationId, UserId? UserId);
}
