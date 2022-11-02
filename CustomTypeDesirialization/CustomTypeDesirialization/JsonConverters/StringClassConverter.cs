using System.Text.Json;
using System.Text.Json.Serialization;

namespace CustomTypeDesirialization.JsonConverters
{
    public class StringClassConverter<T> : JsonConverter<T>
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var value = reader.GetString();
                if (!string.IsNullOrWhiteSpace(value))
                    return (T)Activator.CreateInstance(typeof(T), value);
            }

            return default(T);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        { 
            throw new NotImplementedException();
        }
    }
}
