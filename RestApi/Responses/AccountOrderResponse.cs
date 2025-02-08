using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.RestApi.Responses {
  public class AccountOrderResponse {
    public decimal? Amount { get; set; }
    public decimal? AmountQuote { get; set; }
    public decimal? AmountQuoteRemaining { get; set; }
    public decimal? AmountRemaining { get; set; }
    public string ClientOrderId { get; set; }
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? Created { get; set; }
    public bool? DisableMarketProtection { get; set; }
    public string FeeCurrency { get; set; }
    public decimal? FeePaid { get; set; }
    public decimal? FilledAmount { get; set; }
    public decimal? FilledAmountQuote { get; set; }
    public List<AccountOrderResponseFillItem> Fills { get; set; }
    public string Market { get; set; }
    public decimal? OnHold { get; set; }
    public string OnHoldCurrency { get; set; }
    public Guid? OrderId { get; set; }
    public AccountOrderType? OrderType { get; set; }
    public bool? PostOnly { get; set; }
    public decimal? Price { get; set; }
    public AccountOrderSelfTradePrevention? SelfTradePrevention { get; set; }
    public TransactionSide? Side { get; set; }
    public AccountOrderStatus? Status { get; set; }
    public AccountOrderTimeInForce? TimeInForce { get; set; }
    public decimal? TriggerAmount { get; set; }
    public decimal? TriggerPrice { get; set; }
    public AccountOrderTriggerReference? TriggerReference { get; set; }
    public string TriggerType { get; set; }
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? Updated { get; set; }
    public bool? Visible { get; set; }
  }
}