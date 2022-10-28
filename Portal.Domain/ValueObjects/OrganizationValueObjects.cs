using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.ValueObjects.Organizations
{
    public record OrganizationId(Guid Value) : ISingleValueObject<Guid> { }
    public record OrganizationShortName(string Value) : ISingleValueObject<string> { }
    public record OrganizationName(string Value) : ISingleValueObject<string> { }
    public record Authority(string Value) : ISingleValueObject<string> { }
    public record ClientId(string Value) : ISingleValueObject<string> { }
    public record ClientSecret(string Value) : ISingleValueObject<string>{}
    public record OrganizationMsalConfiguration(Authority Authority, ClientId Id, ClientSecret Secret);


}
