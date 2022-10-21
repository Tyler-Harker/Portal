using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.ValueObjects.CustomDomains
{
    public record Domain(string Value) : ISingleValueObject<string> { }
}
