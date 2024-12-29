using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<RestApiPath>))]
  public enum RestApiPath {
    [Description("account")]
    Account,
    [Description("account/fees")]
    AccountFees,
    [Description("account/history")]
    AccountHistory,
    [Description("assets")]
    Assets,
    [Description("balance")]
    Balance,
    [Description("deposit")]
    Deposit,
    [Description("depositHistory")]
    DepositHistory,
    [Description("market/book")]
    MarketBook,
    [Description("market/candles")]
    MarketCandles,
    [Description("markets")]
    Markets,
    [Description("market/trades")]
    MarketTrades,
    [Description("ordersOpen")]
    OpenOrders,
    [Description("order")]
    Order,
    [Description("orders")]
    Orders,
    [Description("ticker/24h")]
    Ticker24h,
    [Description("ticker/book")]
    TickerBook,
    [Description("ticker/price")]
    TickerPrice,
    [Description("time")]
    Time,
    [Description("trades")]
    Trades,
    [Description("withdrawal")]
    Withdrawal,
    [Description("withdrawalHistory")]
    WithdrawalHistory,
  }
}