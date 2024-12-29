using System;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.WebSocketApi.Receives {
  public class ReceiveSubscriptionMarketTicker24h {
    public decimal? Ask { get; set; }
    public decimal? AskSize { get; set; }
    public decimal? Bid { get; set; }
    public decimal? BidSize { get; set; }
    public decimal? High { get; set; }
    public decimal? Last { get; set; }
    public decimal? Low { get; set; }
    public string Market { get; set; }
    public decimal? Open { get; set; }
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? Timestamp { get; set; }
    public decimal? Volume { get; set; }
    public decimal? VolumeQuote { get; set; }
  }
}