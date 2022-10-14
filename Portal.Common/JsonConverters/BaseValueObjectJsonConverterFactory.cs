using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portal.Common.JsonConverters
{
    public class BaseValueObjectJsonConverterFactory : JsonConverterFactory
    {
        static Dictionary<Type, Type?> TypesBaseGenericType = new Dictionary<Type, Type?>();
        static Dictionary<Type, JsonConverter> TypeJsonConverters = new Dictionary<Type, JsonConverter>();
        public static Dictionary<Type, Type> TypesGenericType = new Dictionary<Type, Type>();
        public override bool CanConvert(Type typeToConvert)
        {
            if(typeToConvert.IsSubclassOf(typeof(BaseValueObject)))
            {
                var baseGenericType = GetBaseGenericType(typeToConvert);
                return baseGenericType != null;
            }
            return false;
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var baseType = GetBaseGenericType(typeToConvert);

            Type parameterType;

            if (TypesGenericType.ContainsKey(typeToConvert))
            {
                parameterType = TypesGenericType[typeToConvert];
            }
            else
            {
                parameterType = baseType.GenericTypeArguments.First();
                TypesGenericType.Add(typeToConvert, parameterType);
            }


            JsonConverter converter;

            if (TypeJsonConverters.ContainsKey(parameterType))
            {
                converter = (JsonConverter)TypeJsonConverters[parameterType];
            }
            else
            {
                var jsonConverterType = typeof(BaseValueObjectJsonConverter<>).MakeGenericType(parameterType);
                converter = (JsonConverter)Activator.CreateInstance(jsonConverterType);

                TypeJsonConverters.Add(parameterType, converter);
            }
            return converter;
        }




        private Type? GetBaseGenericType(Type? type)
        {
            if(type == null)
            {
                return null;
            }
            else if (TypesBaseGenericType.ContainsKey(type))
            {
                return TypesBaseGenericType[type];
            }
            else
            {
                if (type.IsGenericType)
                {
                    return type;
                }
                else
                {
                    var baseGenericType = GetBaseGenericType(type.BaseType);
                    TypesBaseGenericType.Add(type, baseGenericType);
                    return baseGenericType;
                }
            }
        }
    }

    public class BaseValueObjectJsonConverter<T> : JsonConverter<BaseValueObject<T>>
    {
        public override BaseValueObject<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var valueType = BaseValueObjectJsonConverterFactory.TypesGenericType[typeToConvert];
            var nextToken = reader.Read();

            object value = new object();
            if (RepresentAsString(valueType))
            {
                value = reader.GetString();
            }
            else
            {
                switch (Type.GetTypeCode(valueType))
                {
                    case TypeCode.Byte: value = reader.GetByte(); break;
                    case TypeCode.SByte: value = reader.GetSByte(); break;
                    case TypeCode.UInt16: value = reader.GetUInt16(); break;
                    case TypeCode.UInt32: value = reader.GetUInt32(); break;
                    case TypeCode.UInt64: value = reader.GetUInt64(); break;
                    case TypeCode.Int16: value = reader.GetInt16(); break;
                    case TypeCode.Int32: value = reader.GetInt32(); break;
                    case TypeCode.Int64: value = reader.GetInt64(); break;
                    case TypeCode.Decimal: value = reader.GetDecimal(); break;
                    case TypeCode.Double: value = reader.GetDouble(); break;
                    case TypeCode.Single: value = reader.GetSingle(); break;
                    case TypeCode.Boolean: value = reader.GetBoolean(); break;
                    default: break;
                }
            }

            return (BaseValueObject<T>)Activator.CreateInstance(typeToConvert, (object)value);
        }

        public override void Write(Utf8JsonWriter writer, BaseValueObject<T> value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(JsonSerializer.Serialize(value.Value));
            //if (RepresentAsString(typeof(T)))
            //{
            //    writer.WriteRawValue($"{value.Value.ToString()}");
            //}
            //else
            //{
            //    writer.WriteRawValue($"{value.Value}");
            //}
        }

        public static bool RepresentAsString(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                case TypeCode.Boolean:
                    return false;
                default:
                    return true;
            }
        }
    }

}
