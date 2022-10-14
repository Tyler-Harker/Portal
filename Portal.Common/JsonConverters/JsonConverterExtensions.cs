using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Portal.Common.JsonConverters
{
    public static class JsonConverterExtensions
    {
        public static JsonSerializerOptions AddCustomJsonConverters(this JsonSerializerOptions options)
        {
            options.Converters.Add(new BaseValueObjectJsonConverterFactory());
            return options;
        }
    }
}
