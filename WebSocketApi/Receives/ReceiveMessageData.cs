using System.Collections.Generic;
using tar.Bitvavo.Api.RestApi.Responses;

namespace tar.Bitvavo.Api.WebSocketApi.Receives {
  public class ReceiveMessageData {
    public AccountResponse Account { get; set; }
    public List<AccountBalanceResponse> AccountBalance { get; set; }
    public AccountCancelOrderResponse AccountCancelOrder { get; set; }
    public List<AccountCancelOrderResponse> AccountCancelOrders { get; set; }
    public AccountDepositAddressResponse AccountDepositAddress { get; set; }
    public List<AccountDepositHistoryResponse> AccountDepositHistory { get; set; }
    public AccountFeesResponse AccountFees { get; set; }
    public AccountOrderResponse AccountOrder { get; set; }
    public List<AccountOrderResponse> AccountOrders { get; set; }
    public List<AccountTradeResponse> AccountTrades { get; set; }
    public AccountTransactionHistoryResponse AccountTransactionHistory { get; set; }
    public List<AccountWithdrawalHistoryResponse> AccountWithdrawalHistory { get; set; }
    public AccountWithdrawAssetResponse AccountWithdrawAsset { get; set; }
    public MarketAssetResponse MarketAsset { get; set; }
    public List<MarketAssetResponse> MarketAssets { get; set; }
    public MarketResponse Market { get; set; }
    public List<MarketCandlesResponse> MarketCandles { get; set; }
    public MarketOrderBookResponse MarketOrderBook { get; set; }
    public List<MarketResponse> Markets { get; set; }
    public List<MarketTicker24hResponse> MarketsTicker24h { get; set; }
    public List<MarketTickerBookResponse> MarketsTickerBook { get; set; }
    public List<MarketTickerPriceResponse> MarketsTickerPrice { get; set; }
    public MarketTicker24hResponse MarketTicker24h { get; set; }
    public MarketTickerBookResponse MarketTickerBook { get; set; }
    public MarketTickerPriceResponse MarketTickerPrice { get; set; }
    public List<MarketTradesResponse> MarketTrades { get; set; }
    public ServerTimeResponse ServerTime { get; set; }
  }
}