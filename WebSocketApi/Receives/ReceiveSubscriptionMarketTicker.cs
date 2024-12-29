namespace tar.Bitvavo.Api.WebSocketApi.Receives {
  public class ReceiveSubscriptionMarketTicker {
    public decimal? BestAsk { get; set; }
    public decimal? BestAskSize { get; set; }
    public decimal? BestBid { get; set; }
    public decimal? BestBidSize { get; set; }
    public decimal? LastPrice { get; set; }
    public string Market { get; set; }
  }
}