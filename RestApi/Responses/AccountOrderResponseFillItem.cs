using System;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.RestApi.Responses {
  public class AccountOrderResponseFillItem {
    public decimal? Amount { get; set; }
    public decimal? Fee { get; set; }
    public string FeeCurrency { get; set; }
    public Guid? Id { get; set; }
    public decimal? Price { get; set; }
    public bool? Settled { get; set; }
    public bool? Taker { get; set; }
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? Timestamp { get; set; }
  }
}