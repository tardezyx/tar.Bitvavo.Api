using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;
using tar.Bitvavo.Api.Enums;
using tar.Bitvavo.Api.RestApi.Requests;

namespace tar.Bitvavo.Api.WebSocketApi.Sends {
  public class SendPayload {
    public WebSocketAction? Action { get; }
    public string Address { get; }
    public bool? AddWithdrawalFee { get; }
    [JsonConverter(typeof(DecimalConverter))]
    public decimal? Amount { get; }
    [JsonConverter(typeof(DecimalConverter))]
    public decimal? AmountQuote { get; }
    [JsonConverter(typeof(DecimalConverter))]
    public decimal? AmountRemaining { get; }
    public string Base { get; }
    public List<SubscriptionChannel> Channels { get; }
    public string ClientOrderId { get; }
    public int? Depth { get; }
    public bool? DisableMarketProtection { get; }
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? End { get; set; }
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? FromDate { get; set; }
    public MarketInterval? Interval { get; }
    public string Key { get; }
    public int? Limit { get; }
    public string Market { get; }
    public int? MaxItems { get; }
    public Guid? OrderId { get; }
    public Guid? OrderIdFrom { get; }
    public Guid? OrderIdTo { get; }
    public AccountOrderType? OrderType { get; }
    public int? Page { get; }
    public string PaymentId { get; }
    public bool? PostOnly { get; }
    [JsonConverter(typeof(DecimalConverter))]
    public decimal? Price { get; }
    public FeeQuote? Quote { get; }
    public long? RequestId { get; }
    public bool? ResponseRequired { get; }
    public AccountOrderSelfTradePrevention? SelfTradePrevention { get; }
    public TransactionSide? Side { get; }
    public string Signature { get; }
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? Start { get; set; }
    public string Symbol { get; }
    public AccountOrderTimeInForce? TimeInForce { get; }
    public long? Timestamp { get; }
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? ToDate { get; set; }
    public Guid? TradeIdFrom { get; }
    public Guid? TradeIdTo { get; }
    [JsonConverter(typeof(DecimalConverter))]
    public decimal? TriggerAmount { get; }
    public AccountOrderTriggerReference? TriggerReference { get; }
    public string TriggerType { get; }
    public AccountTransactionType? Type { get; }
    public int? Window { get; }

    public SendPayload(
      WebSocketAction? action = null,
      string address = null,
      bool? addWithdrawalFee = null,
      decimal? amount = null,
      decimal? amountQuote = null,
      decimal? amountRemaining = null,
      string @base = null,
      List<SubscriptionChannel> channels = null,
      string clientOrderId = null,
      int? depth = null,
      bool? disableMarketProtection = null,
      DateTime? end = null,
      DateTime? fromDate = null,
      MarketInterval? interval = null,
      string key = null,
      int? limit = null,
      string market = null,
      int? maxItems = null,
      Guid? orderId = null,
      Guid? orderIdFrom = null,
      Guid? orderIdTo = null,
      AccountOrderType? orderType = null,
      int? page = null,
      string paymentId = null,
      bool? postOnly = null,
      decimal? price = null,
      FeeQuote? quote = null,
      long? requestId = null,
      bool? responseRequired = null,
      AccountOrderSelfTradePrevention? selfTradePrevention = null,
      TransactionSide? side = null,
      string signature = null,
      DateTime? start = null,
      string symbol = null,
      AccountOrderTimeInForce? timeInForce = null,
      long? timestamp = null,
      DateTime? toDate = null,
      Guid? tradeIdFrom = null,
      Guid? tradeIdTo = null,
      decimal? triggerAmount = null,
      AccountOrderTriggerReference? triggerReference = null,
      string triggerType = null,
      AccountTransactionType? type = null,
      int? window = null
    ) {
      Action = action;
      Address = address;
      AddWithdrawalFee = addWithdrawalFee;
      Amount = amount;
      AmountQuote = amountQuote;
      AmountRemaining = amountRemaining;
      Base = @base;
      Channels = channels;
      ClientOrderId = clientOrderId;
      Depth = depth;
      DisableMarketProtection = disableMarketProtection;
      End = end;
      FromDate = fromDate;
      Interval = interval;
      Key = key;
      Limit = limit;
      Market = market;
      MaxItems = maxItems;
      OrderId = orderId;
      OrderIdFrom = orderIdFrom;
      OrderIdTo = orderIdTo;
      OrderType = orderType;
      Page = page;
      PaymentId = paymentId;
      PostOnly = postOnly;
      Price = price;
      Quote = quote;
      RequestId = requestId;
      ResponseRequired = responseRequired;
      SelfTradePrevention = selfTradePrevention;
      Side = side;
      Signature = signature;
      Start = start;
      Symbol = symbol;
      TimeInForce = timeInForce;
      Timestamp = timestamp;
      ToDate = toDate;
      TradeIdFrom = tradeIdFrom;
      TradeIdTo = tradeIdTo;
      TriggerAmount = triggerAmount;
      TriggerReference = triggerReference;
      TriggerType = triggerType;
      Type = type;
      Window = window;
    }
  }
}