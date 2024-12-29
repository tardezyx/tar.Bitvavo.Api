using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<FeeQuote>))]
  public enum FeeQuote {
    [Description("EUR")]
    Euro,
    [Description("USDC")]
    UsdCoin
  }
}