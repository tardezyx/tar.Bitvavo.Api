using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using tar.Bitvavo.Extensions;

namespace tar.Bitvavo.Api.Converters {
  internal class DecimalConverter : JsonConverter<decimal?> {
    public override bool CanConvert(Type objectType) {
      return true;
    }

    public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
      string item = JsonSerializer.Deserialize<string>(ref reader, options);

      if (
        item.HasText()
        && decimal.TryParse(item, NumberStyles.Integer, CultureInfo.InvariantCulture, out decimal result)
      ) {
        return result;
      }

      return null;
    }

    public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options) {
      if (value is decimal validValue) {
        JsonSerializer.Serialize(writer, validValue.ToString(CultureInfo.InvariantCulture));
      }
    }
  }
}