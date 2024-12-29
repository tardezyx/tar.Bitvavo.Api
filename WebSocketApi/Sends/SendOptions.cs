using System;
using System.Collections.Generic;
using tar.Bitvavo.Api.Enums;
using tar.Bitvavo.Api.RestApi.Requests;

namespace tar.Bitvavo.Api.WebSocketApi.Sends {
  public class SendOptions {
    public WebSocketAction Action { get; }
    public bool AuthRequired { get; }
    public string Base { get; }
    public int? Depth { get; }
    public List<SubscriptionChannel> Channels { get; }
    public DateTime? End { get; }
    public DateTime? FromDate { get; }
    public MarketInterval? Interval { get; }
    public string Key { get; }
    public int? Limit { get; }
    public string Market { get; }
    public int? MaxItems { get; }
    public Guid? OrderId { get; }
    public Guid? OrderIdFrom { get; }
    public bool OrderIdIsClientOrderId { get; }
    public Guid? OrderIdTo { get; }
    public AccountOrderType? OrderType { get; }
    public int? Page { get; }
    public AccountPlaceOrderOptions PlaceOrderOptions { get; }
    public FeeQuote? Quote { get; }
    public long? RequestId { get; }
    public TransactionSide? Side { get; }
    public string Signature { get; }
    public DateTime? Start { get; }
    public string Symbol { get; }
    public long? Timestamp { get; }
    public DateTime? ToDate { get; }
    public Guid? TradeIdFrom { get; }
    public Guid? TradeIdTo { get; }
    public AccountTransactionType? TransactionType { get; }
    public AccountUpdateOrderOptions UpdateOrderOptions { get; }
    public int? Window { get; }
    public AccountWithdrawal Withdrawal { get; }

    public SendOptions(
      WebSocketAction action,
      bool authRequired = false,
      string @base = null,
      List<SubscriptionChannel> channels = null,
      int? depth = null,
      DateTime? end = null,
      DateTime? fromDate = null,
      MarketInterval? interval = null,
      string key = null,
      int? limit = null,
      string market = null,
      int? maxItems = null,
      Guid? orderId = null,
      Guid? orderIdFrom = null,
      bool orderIdIsClientOrderId = false,
      Guid? orderIdTo = null,
      AccountOrderType? orderType = null,
      int? page = null,
      AccountPlaceOrderOptions placeOrderOptions = null,
      FeeQuote? quote = null,
      long? requestId = null,
      TransactionSide? side = null,
      string signature = null,
      DateTime? start = null,
      string symbol = null,
      long? timestamp = null,
      DateTime? toDate = null,
      Guid? tradeIdFrom = null,
      Guid? tradeIdTo = null,
      AccountTransactionType? transactionType = null,
      AccountUpdateOrderOptions updateOrderOptions = null,
      int? window = null,
      AccountWithdrawal withdrawal = null
    ) {
      Action = action;
      AuthRequired = authRequired;
      Base = @base;
      Channels = channels;
      Depth = depth;
      End = end;
      FromDate = fromDate;
      Interval = interval;
      Key = key;
      Limit = limit;
      Market = market;
      MaxItems = maxItems;
      OrderId = orderId;
      OrderIdFrom = orderIdFrom;
      OrderIdIsClientOrderId = orderIdIsClientOrderId;
      OrderIdTo = orderIdTo;
      OrderType = orderType;
      Page = page;
      PlaceOrderOptions = placeOrderOptions;
      Quote = quote;
      RequestId = requestId;
      Side = side;
      Signature = signature;
      Start = start;
      Symbol = symbol;
      Timestamp = timestamp;
      ToDate = toDate;
      TradeIdFrom = tradeIdFrom;
      TradeIdTo = tradeIdTo;
      TransactionType = transactionType;
      UpdateOrderOptions = updateOrderOptions;
      Window = window;
      Withdrawal = withdrawal;
    }
  }
}