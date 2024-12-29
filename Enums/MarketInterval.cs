using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<MarketInterval>))]
  public enum MarketInterval {
    [Description("1m")]
    _1m,
    [Description("5m")]
    _5m,
    [Description("15m")]
    _15m,
    [Description("30m")]
    _30m,
    [Description("1h")]
    _1h,
    [Description("2h")]
    _2h,
    [Description("4h")]
    _4h,
    [Description("6h")]
    _6h,
    [Description("8h")]
    _8h,
    [Description("12h")]
    _12h,
    [Description("1d")]
    _1d,
  }
}