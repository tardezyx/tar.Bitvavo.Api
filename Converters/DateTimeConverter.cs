using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Extensions;

namespace tar.Bitvavo.Api.Converters {
  internal class DateTimeConverter : JsonConverter<DateTime?> {
    public override bool CanConvert(Type objectType) {
      return true;
    }

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
      long? item = JsonSerializer.Deserialize<long>(ref reader, options);

      if (item is long longValue) {
        return longValue.ToDateTimeFromUnixTimeMilliseconds();
      }

      return null;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options) {
      if (value is DateTime dateTime) {
        JsonSerializer.Serialize(writer, dateTime.ToUnixTimeMilliseconds());
      }
    }
  }
}