using System;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.RestApi.Responses {
  public class AccountWithdrawalHistoryResponse {
    public string Address { get; set; }
    public decimal? Amount { get; set; }
    public decimal? Fee { get; set; }
    public string PaymentId { get; set; }
    public AccountWithdrawalStatus? Status { get; set; }
    public string Symbol { get; set; }
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? Timestamp { get; set; }
    public string TxId { get; set; }
  }
}