using System;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.RestApi.Requests {
  internal class RestRequestBody {
    public string Address { get; }
    public bool? AddWithdrawalFee { get; }
    [JsonConverter(typeof(DecimalConverter))]
    public decimal? Amount { get; }
    [JsonConverter(typeof(DecimalConverter))]
    public decimal? AmountQuote { get; }
    [JsonConverter(typeof(DecimalConverter))]
    public decimal? AmountRemaining { get; }
    public Guid? ClientOrderId { get; }
    public bool? DisableMarketProtection { get; }
    public string Market { get; }
    public Guid? OrderId { get; }
    public AccountOrderType? OrderType { get; }
    public string PaymentId { get; }
    public bool? PostOnly { get; }
    [JsonConverter(typeof(DecimalConverter))]
    public decimal? Price { get; }
    public bool? ResponseRequired { get; }
    public AccountOrderSelfTradePrevention? SelfTradePrevention { get; }
    public TransactionSide? Side { get; }
    public string Symbol { get; }
    public AccountOrderTimeInForce? TimeInForce { get; }
    [JsonConverter(typeof(DecimalConverter))]
    public decimal? TriggerAmount { get; }
    public AccountOrderTriggerReference? TriggerReference { get; }
    public string TriggerType { get; }

    public RestRequestBody(
      string address = null,
      bool? addWithdrawalFee = null,
      decimal? amount = null,
      decimal? amountQuote = null,
      decimal? amountRemaining = null,
      Guid? clientOrderId = null,
      bool? disableMarketProtection = null,
      string market = null,
      Guid? orderId = null,
      AccountOrderType? orderType = null,
      string paymentId = null,
      bool? postOnly = null,
      decimal? price = null,
      bool? responseRequired = null,
      AccountOrderSelfTradePrevention? selfTradePrevention = null,
      TransactionSide? side = null,
      string symbol = null,
      AccountOrderTimeInForce? timeInForce = null,
      decimal? triggerAmount = null,
      AccountOrderTriggerReference? triggerReference = null,
      string triggerType = null
    ) {
      Address = address;
      AddWithdrawalFee = addWithdrawalFee;
      Amount = amount;
      AmountQuote = amountQuote;
      AmountRemaining = amountRemaining;
      ClientOrderId = clientOrderId;
      DisableMarketProtection = disableMarketProtection;
      Market = market;
      OrderId = orderId;
      OrderType = orderType;
      PaymentId = paymentId;
      PostOnly = postOnly;
      Price = price;
      ResponseRequired = responseRequired;
      SelfTradePrevention = selfTradePrevention;
      Side = side;
      Symbol = symbol;
      TimeInForce = timeInForce;
      TriggerAmount = triggerAmount;
      TriggerReference = triggerReference;
      TriggerType = triggerType;
    }
  }
}