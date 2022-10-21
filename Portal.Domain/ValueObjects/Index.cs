using Portal.Domain.ValueObjects.Users;
using System;
using System.Collections.Generic;
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
    public record SkipTake(int Skip, int Take) { }
    public record Page<TResult>(SkipTake SkipTake, IReadOnlyCollection<TResult> Results, int TotalRecords) { }
}
