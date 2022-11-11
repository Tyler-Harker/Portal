using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.ValueObjects.Users
{
    public record UserId(Guid Value) : ISingleValueObject<Guid> { }
    public record FirstName(string Value) : ISingleValueObject<string> { }
    public record LastName(string Value) : ISingleValueObject<string> { }
    public record Username(Email Value) : ISingleValueObject<Email> { }
    
    public record UserTableData(UserId Id, FirstName FirstName, LastName LastName, Username Username, IsActive IsActive);
}
