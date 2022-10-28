using Portal.Domain.ValueObjects;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Portal.WebApi.Utilities
{
    public class ValueObjectJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return false;
            var result = typeToConvert.IsSubclassOf(typeof(ISingleValueObject));
            return result;
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {

            throw new NotImplementedException();
        }
    }
}
