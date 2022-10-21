using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.ValueObjects
{
    public record UtcDateTime(DateTime value) : ISingleValueObject<DateTime> { public DateTime Value => value.ToUniversalTime(); }
    public record CreatedById(Users.Id Value) : ISingleValueObject<Users.Id> { }
    public record CreatedByImpersonatorId(Users.Id Value) : ISingleValueObject<Users.Id> { }
    public record UpdatedById(Users.Id Value) : ISingleValueObject<Users.Id> { }
    public record UpdatedByImpersonatorId(Users.Id Value) : ISingleValueObject<Users.Id> { }
    public record CreatedAt(UtcDateTime Value) : ISingleValueObject<UtcDateTime> { }
    public record UpdatedAt(UtcDateTime Value) : ISingleValueObject<UtcDateTime> { }
}
