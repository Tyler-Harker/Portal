﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.ValueObjects.Organizations
{
    public record Id(string Value) : ISingleValueObject<string> { }
    public record Name(string Value) : ISingleValueObject<string> { }
}