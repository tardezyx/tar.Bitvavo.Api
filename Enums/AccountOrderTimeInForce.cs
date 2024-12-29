using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<AccountOrderTimeInForce>))]
  public enum AccountOrderTimeInForce {
    [Description("FOK")]
    FillOrKill,
    [Description("GTC")]
    GoodTilCanceled,
    [Description("IOC")]
    ImmediateOrCancel
  }
}