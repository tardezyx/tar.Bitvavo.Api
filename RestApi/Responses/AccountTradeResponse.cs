using System;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.RestApi.Responses {
  public class AccountTradeResponse {
    public decimal? Amount { get; set; }
    public Guid? ClientOrderId { get; set; }
    public decimal? Fee { get; set; }
    public string FeeCurrency { get; set; }
    public Guid? Id { get; set; }
    public string Market { get; set; }
    public Guid? OrderId { get; set; }
    public decimal? Price { get; set; }
    public bool? Settled { get; set; }
    public TransactionSide? Side { get; set; }
    public bool? Taker { get; set; }
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? Timestamp { get; set; }
  }
}