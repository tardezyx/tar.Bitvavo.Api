using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using tar.Bitvavo.Extensions;

namespace tar.Bitvavo.Api.Converters {
  internal class EnumConverter<T> : JsonConverter<T> where T : Enum {
    public override bool CanConvert(Type objectType) {
      return true;
    }

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
      string item = JsonSerializer.Deserialize<string>(ref reader, options);

      return item.ToEnumByDescription<T>();
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) {
      JsonSerializer.Serialize(writer, value.GetDescription());
    }
  }
}