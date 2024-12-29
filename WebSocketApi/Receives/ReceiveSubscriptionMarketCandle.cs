using System;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.WebSocketApi.Receives {
  public class ReceiveSubscriptionMarketCandle {
    public decimal? Close { get; set; }
    public decimal? High { get; set; }
    public MarketInterval? Interval { get; set; }
    public decimal? Low { get; set; }
    public string Market { get; set; }
    public decimal? Open { get; set; }
    public DateTime? Timestamp { get; set; }
    public decimal? Volume { get; set; }
  }
}