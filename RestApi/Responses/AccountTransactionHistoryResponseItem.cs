using System;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.RestApi.Responses {
  public class AccountTransactionHistoryResponseItem {
    public string Address { get; set; }
    public DateTime? ExecutedAt { get; set; }
    public decimal? FeesAmount { get; set; }
    public string FeesCurrency { get; set; }
    public decimal? PriceAmount { get; set; }
    public string PriceCurrency { get; set; }
    public decimal? ReceivedAmount { get; set; }
    public string ReceivedCurrency { get; set; }
    public decimal? SentAmount { get; set; }
    public string SentCurrency { get; set; }
    public Guid? TransactionId { get; set; }
    public AccountTransactionType? Type { get; set; }
  }
}