using System.Collections.Generic;

namespace tar.Bitvavo.Api.WebSocketApi.Receives {
  public class ReceiveMessageSubscriptionData {
    public ReceiveSubscriptionAccountOrder AccountOrder { get; set; }
    public ReceiveSubscriptionAccountOrderFill AccountOrderFill { get; set; }
    public List<ReceiveSubscriptionMarketCandle> MarketCandles { get; set; }
    public ReceiveSubscriptionMarketOrderBook MarketOrderBook { get; set; }
    public ReceiveSubscriptionMarketTicker MarketTicker { get; set; }
    public List<ReceiveSubscriptionMarketTicker24h> MarketTicker24h { get; set; }
    public ReceiveSubscriptionMarketTrade MarketTrade { get; set; }
  }
}