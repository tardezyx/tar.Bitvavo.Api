using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<AccountOrderTriggerReference>))]
  public enum AccountOrderTriggerReference {
    [Description("bestAsk")]
    BestAsk,
    [Description("bestBid")]
    BestBid,
    [Description("lastTrade")]
    LastTrade,
    [Description("midPrice")]
    MidPrice
  }
}