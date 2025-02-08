using RestSharp;
using System;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.RestApi.Requests {
  public class RestRequestOptions {
    public Method ApiMethod { get; }
    public RestApiPath ApiPath { get; }
    public string ApiPathMarket { get; }
    public bool AddSignature { get; }
    public string Base { get; }
    public string ClientOrderId { get; }
    public int? Depth { get; }
    public DateTime? End { get; }
    public DateTime? FromDate { get; }
    public MarketInterval? Interval { get; }
    public int? Limit { get; }
    public string Market { get; }
    public int? MaxItems { get; }
    public Guid? OrderId { get; }
    public Guid? OrderIdFrom { get; }
    public Guid? OrderIdTo { get; }
    public AccountOrderType? OrderType { get; }
    public int? Page { get; }
    public AccountPlaceOrderOptions PlaceOrderOptions { get; }
    public FeeQuote? Quote { get; }
    public TransactionSide? Side { get; }
    public DateTime? Start { get; }
    public string Symbol { get; }
    public DateTime? ToDate { get; }
    public Guid? TradeIdFrom { get; }
    public Guid? TradeIdTo { get; }
    public AccountTransactionType? TransactionType { get; }
    public AccountUpdateOrderOptions UpdateOrderOptions { get; }
    public AccountWithdrawal Withdrawal { get; }

    public RestRequestOptions(
      Method apiMethod,
      RestApiPath apiPath,
      string apiPathMarket = null,
      bool addSignature = false,
      string @base = null,
      string clientOrderId = null,
      int? depth = null,
      DateTime? end = null,
      DateTime? fromDate = null,
      MarketInterval? interval = null,
      int? limit = null,
      string market = null,
      int? maxItems = null,
      Guid? orderId = null,
      Guid? orderIdFrom = null,
      Guid? orderIdTo = null,
      AccountOrderType? orderType = null,
      int? page = null,
      AccountPlaceOrderOptions placeOrderOptions = null,
      FeeQuote? quote = null,
      TransactionSide? side = null,
      DateTime? start = null,
      string symbol = null,
      DateTime? toDate = null,
      Guid? tradeIdFrom = null,
      Guid? tradeIdTo = null,
      AccountTransactionType? transactionType = null,
      AccountUpdateOrderOptions updateOrderOptions = null,
      AccountWithdrawal withdrawal = null
    ) {
      ApiMethod = apiMethod;
      ApiPath = apiPath;
      ApiPathMarket = apiPathMarket;
      AddSignature = addSignature;
      Base = @base;
      ClientOrderId = clientOrderId;
      Depth = depth;
      End = end;
      FromDate = fromDate;
      Interval = interval;
      Limit = limit;
      Market = market;
      MaxItems = maxItems;
      OrderId = orderId;
      OrderIdFrom = orderIdFrom;
      OrderIdTo = orderIdTo;
      OrderType = orderType;
      Page = page;
      PlaceOrderOptions = placeOrderOptions;
      Quote = quote;
      Side = side;
      Start = start;
      Symbol = symbol;
      ToDate = toDate;
      TradeIdFrom = tradeIdFrom;
      TradeIdTo = tradeIdTo;
      TransactionType = transactionType;
      UpdateOrderOptions = updateOrderOptions;
      Withdrawal = withdrawal;
    }
  }
}