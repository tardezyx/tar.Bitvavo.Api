using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.RestApi.Responses {
  [JsonConverter(typeof(AmountPriceResponseConverter))]
  public class AmountPriceResponse {
    public decimal? Amount { get; set; }
    public decimal? Price { get; set; }
  }
}