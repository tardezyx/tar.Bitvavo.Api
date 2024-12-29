using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<TransactionSide>))]
  public enum TransactionSide {
    [Description("buy")]
    Buy,
    [Description("sell")]
    Sell
  }
}