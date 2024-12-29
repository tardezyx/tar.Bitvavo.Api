using System;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.WebSocketApi.Receives {
  public class ReceiveSubscriptionMarketTrade {
    public decimal? Amount { get; set; }
    public Guid? Id { get; set; }
    public string Market { get; set; }
    public decimal? Price { get; set; }
    public TransactionSide? Side { get; set; }
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? Timestamp { get; set; }
  }
}