using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<MarketStatus>))]
  public enum MarketStatus {
    [Description("auction")]
    Auction,
    [Description("halted")]
    Halted,
    [Description("trading")]
    Trading
  }
}