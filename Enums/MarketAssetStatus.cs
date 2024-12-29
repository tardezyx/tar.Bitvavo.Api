using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<MarketAssetStatus>))]
  public enum MarketAssetStatus {
    [Description("DELISTED")]
    Delisted,
    [Description("MAINTENANCE")]
    Maintenance,
    [Description("OK")]
    Ok
  }
}