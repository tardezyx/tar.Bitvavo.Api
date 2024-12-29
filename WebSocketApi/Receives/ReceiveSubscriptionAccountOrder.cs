using System;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.WebSocketApi.Receives {
  public class ReceiveSubscriptionAccountOrder {
    public decimal? Amount { get; set; }
    public decimal? AmountRemaining { get; set; }
    public Guid? ClientOrderId { get; set; }
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? Created { get; set; }
    public string Market { get; set; }
    public decimal? Price { get; set; }
    public decimal? OnHold { get; set; }
    public string OnHoldCurrency { get; set; }
    public Guid? OrderId { get; set; }
    public AccountOrderType? OrderType { get; set; }
    public bool? PostOnly { get; set; }
    public AccountOrderSelfTradePrevention? SelfTradePrevention { get; set; }
    public TransactionSide? Side { get; set; }
    public AccountOrderStatus? Status { get; set; }
    public AccountOrderTimeInForce? TimeInForce { get; set; }
    public decimal? TriggerAmount { get; set; }
    public AccountOrderTriggerReference? TriggerReference { get; set; }
    public string TriggerType { get; set; }
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? Updated { get; set; }
    public bool? Visible { get; set; }
  }
}