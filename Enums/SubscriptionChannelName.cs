using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<SubscriptionChannelName>))]
  public enum SubscriptionChannelName {
    [Description("account")]
    Account,
    [Description("book")]
    Book,
    [Description("candles")]
    Candles,
    [Description("ticker")]
    Ticker,
    [Description("ticker24h")]
    Ticker24h,
    [Description("trades")]
    Trades
  }
}