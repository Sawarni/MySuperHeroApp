using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MySuperHeroApp.ApiService.Jobs.Core
{
    public class NullStringConverter : JsonConverter<string?>
    {
        public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var value = reader.GetString();
                return value == "null" ? null : value;
            }
            return null;
        }

        public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value ?? "null");
        }
    }
}
