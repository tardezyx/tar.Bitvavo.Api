using System;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.RestApi.Responses {
  [JsonConverter(typeof(MarketCandlesResponseConverter))]
  public class MarketCandlesResponse {
    public decimal? Close { get; set; }
    public decimal? High { get; set; }
    public decimal? Low { get; set; }
    public decimal? Open { get; set; }
    public DateTime? Timestamp { get; set; }
    public decimal? Volume { get; set; }
  }
}