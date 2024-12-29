using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<AccountOrderType>))]
  public enum AccountOrderType {
    [Description("limit")]
    Limit,
    [Description("market")]
    Market,
    [Description("stopLoss")]
    StopLoss,
    [Description("stopLossLimit")]
    StopLossLimit,
    [Description("takeProfit")]
    TakeProfit,
    [Description("takeProfitLimit")]
    TakeProfitLimit
  }
}