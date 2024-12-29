using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Extensions;
using tar.Bitvavo.Api.RestApi.Responses;
using tar.Bitvavo.Extensions;

namespace tar.Bitvavo.Api.Converters {
  internal class MarketCandlesResponseConverter : JsonConverter<MarketCandlesResponse> {
    public override bool CanConvert(Type objectType) {
      return true;
    }

    public override MarketCandlesResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
      if (
        reader.TokenType == JsonTokenType.StartArray
        && JsonSerializer.Deserialize<List<object>>(ref reader, options) is List<object> item
      ) {
        long? timestamp = null;

        if (item[0]?.ToString() is string timestampString) {
          timestamp = long.Parse(timestampString, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        MarketCandlesResponse marketCandlesResponse = new MarketCandlesResponse() {
          Close = item[4].ToString().ToDecimalOrNull(),
          High = item[2].ToString().ToDecimalOrNull(),
          Low = item[3].ToString().ToDecimalOrNull(),
          Open = item[1].ToString().ToDecimalOrNull(),
          Timestamp = timestamp?.ToDateTimeFromUnixTimeMilliseconds(),
          Volume = item[5].ToString().ToDecimalOrNull()
        };

        return marketCandlesResponse;
      }

      return null;
    }

    public override void Write(Utf8JsonWriter writer, MarketCandlesResponse value, JsonSerializerOptions options) {
      object[] result = {
        value.Timestamp is DateTime dateTime ? dateTime.ToUnixTimeMilliseconds() : 0,
        value.Open.ToString(),
        value.High.ToString(),
        value.Low.ToString(),
        value.Close.ToString(),
        value.Volume.ToString()
      };

      JsonSerializer.Serialize(writer, result);
    }
  }
}