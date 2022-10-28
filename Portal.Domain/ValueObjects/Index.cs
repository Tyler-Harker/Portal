using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.ValueObjects
{
    public record UtcDateTime(DateTime value) : ISingleValueObject<DateTime> { public DateTime Value => value.ToUniversalTime(); }
    public record CreatedById(UserId Value) : ISingleValueObject<UserId> { }
    public record CreatedByImpersonatorId(UserId Value) : ISingleValueObject<UserId> { }
    public record UpdatedById(UserId Value) : ISingleValueObject<UserId> { }
    public record UpdatedByImpersonatorId(UserId Value) : ISingleValueObject<UserId> { }
    public record CreatedAt(UtcDateTime Value) : ISingleValueObject<UtcDateTime> { }
    public record UpdatedAt(UtcDateTime Value) : ISingleValueObject<UtcDateTime> { }
    public record IsActive(bool Value) : ISingleValueObject<bool> { }
    public record Email(string Value) : ISingleValueObject<string> { }
    public record SkipTake(int Skip = 0, int Take = 10) { }
    public record Page<TResult>(SkipTake SkipTake, ReadOnlyCollection<TResult> Results, int TotalRecords) { }
}
