using Portal.Domain.ValueObjects;
using Newtonsoft.Json;
using System.Collections;
using Newtonsoft.Json.Linq;
using Portal.Domain.ValueObjects.Organizations;

namespace Portal.Domain.NewtonsoftJsonConverters
{
    public class CustomDictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (typeof(IDictionary).IsAssignableFrom(objectType) ||
                    TypeImplementsGenericInterface(objectType, typeof(IDictionary<,>)));
        }

        private static bool TypeImplementsGenericInterface(Type concreteType, Type interfaceType)
        {
            return concreteType.GetInterfaces()
                   .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType);
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            Type type = value.GetType();
            IEnumerable keys = (IEnumerable)type.GetProperty("Keys").GetValue(value, null);
            IEnumerable values = (IEnumerable)type.GetProperty("Values").GetValue(value, null);
            IEnumerator valueEnumerator = values.GetEnumerator();

            writer.WriteStartArray();
            foreach (object key in keys)
            {
                valueEnumerator.MoveNext();

                writer.WriteStartObject();
                writer.WritePropertyName("key");
                serializer.Serialize(writer, key);
                writer.WritePropertyName("value");
                serializer.Serialize(writer, valueEnumerator.Current);
                writer.WriteEndObject();
            }            writer.WriteEndArray();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var keyType = objectType.GenericTypeArguments[0];
            var keyValueType =  GetValueType(keyType);
            var valueType = objectType.GenericTypeArguments[1];
            var valueValueType = GetValueType(valueType);
            Dictionary<OrganizationShortName, OrganizationId> dictionary = new Dictionary<OrganizationShortName, OrganizationId>();
            var dict = Activator.CreateInstance(objectType);
            var result = (JArray)serializer.Deserialize(reader);
            if(result.Type == JTokenType.Array)
            {
                foreach (var item in (JArray)result)
                {
                    var keyToken = item.Value<JToken>("key");
                    var valueToken = item.Value<JToken>("value");
                    var key = Activator.CreateInstance(keyType, keyToken.Last.ToObject(keyValueType));
                    var value = Activator.CreateInstance(valueType, valueToken.Last.ToObject(valueValueType));
                    objectType.GetMethod("Add").Invoke(dict, new object[] { key, value });
                }
                return dict;

            }
            return dict;
            
            //JsonConvert.DeserializeObject<DictionaryList>(reader.readAs)
        }

        public Type GetValueType(Type type)
        {
            return type.GetInterfaces().Where(i => i.IsGenericType).FirstOrDefault()?.GenericTypeArguments[0];
        }

        public sealed class DictionaryList : List<DictionaryItem>
        {

        }
        public sealed class DictionaryItem
        {
            public DictionaryItemKey Key { get; set; }
            public DictionaryItemValue Value { get; set; }
        }
        public sealed class DictionaryItemKey
        {
            [JsonProperty("$type")]
            public string Type { get; set; }
            public string Value { get; set; }
        }
        public sealed class DictionaryItemValue
        {
            [JsonProperty("$type")]
            public string Type { get; set; }
            public string Value { get; set; }
        }
    }
}
