using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<WebSocketAction>))]
  public enum WebSocketAction {
    [Description("authenticate")]
    Authenticate,
    [Description("privateCancelOrder")]
    AccountCancelOrder,
    [Description("privateCancelOrders")]
    AccountCancelOrders,
    [Description("privateCreateOrder")]
    AccountPlaceOrder,
    [Description("privateUpdateOrder")]
    AccountUpdateOrder,
    [Description("privateWithdrawAssets")]
    AccountWithdrawAssets,
    [Description("privateGetAccount")]
    GetAccount,
    [Description("privateGetBalance")]
    GetAccountBalance,
    [Description("privateDepositAssets")]
    GetAccountDepositAddress,
    [Description("privateGetDepositHistory")]
    GetAccountDepositHistory,
    [Description("privateGetFees")]
    GetAccountFees,
    [Description("privateGetOrdersOpen")]
    GetAccountOpenOrders,
    [Description("privateGetOrder")]
    GetAccountOrder,
    [Description("privateGetOrders")]
    GetAccountOrders,
    [Description("privateGetTrades")]
    GetAccountTrades,
    [Description("privateGetTransactionHistory")]
    GetAccountTransactionHistory,
    [Description("privateGetWithdrawalHistory")]
    GetAccountWithdrawalHistory,
    [Description("getAssets")]
    GetMarketAssets,
    [Description("getCandles")]
    GetMarketCandles,
    [Description("getBook")]
    GetMarketOrderBook,
    [Description("getMarkets")]
    GetMarkets,
    [Description("getTicker24h")]
    GetMarketTicker24h,
    [Description("getTickerBook")]
    GetMarketTickerBook,
    [Description("getTickerPrice")]
    GetMarketTickerPrice,
    [Description("getTrades")]
    GetMarketTrades,
    [Description("getTime")]
    GetServerTime,
    [Description("subscribe")]
    Subscribe,
    [Description("unknown")]
    Unknown,
    [Description("unsubscribe")]
    Unsubscribe
  }
}