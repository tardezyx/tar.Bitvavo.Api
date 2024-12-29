using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.RestApi.Responses;
using tar.Bitvavo.Extensions;

namespace tar.Bitvavo.Api.Converters {
  internal class AmountPriceResponseConverter : JsonConverter<AmountPriceResponse> {
    public override bool CanConvert(Type objectType) {
      return true;
    }

    public override AmountPriceResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
      AmountPriceResponse result = new AmountPriceResponse();

      if (reader.TokenType == JsonTokenType.StartArray) {
        List<string> item = JsonSerializer.Deserialize<List<string>>(ref reader, options);

        if (item != null && item.Count > 1) {
          return new AmountPriceResponse() {
            Amount = item[1].ToDecimalOrNull(),
            Price = item[0].ToDecimalOrNull()
          };
        }
      }

      return result;
    }

    public override void Write(Utf8JsonWriter writer, AmountPriceResponse value, JsonSerializerOptions options) {
      if (value is AmountPriceResponse response) {
        string[] result = {
          response.Price.ToString(),
          response.Amount.ToString()
        };

        JsonSerializer.Serialize(writer, result);
      }
    }
  }
}