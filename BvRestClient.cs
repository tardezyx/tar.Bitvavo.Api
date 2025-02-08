using RestSharp;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;
using tar.Bitvavo.Api.Extensions;
using tar.Bitvavo.Api.RestApi;
using tar.Bitvavo.Api.RestApi.Requests;
using tar.Bitvavo.Api.RestApi.Responses;
using tar.Bitvavo.Extensions;

namespace tar.Bitvavo.Api {
  public class BvRestClient {
    private readonly TimeSpan _accessWindow;
    private readonly string _apiKey;
    private readonly string _apiSecret;
    private readonly RestApiAccountActions _restApiAccountActions;
    private readonly RestApiAccountInfos _restApiAccountInfos;
    private readonly RestApiPublicInfos _restApiPublicInfos;
    private readonly RestClient _restClient;

    internal static JsonSerializerOptions JsonOptions { get; } = new JsonSerializerOptions() {
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
      NumberHandling = JsonNumberHandling.AllowReadingFromString,
      PropertyNameCaseInsensitive = true,
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public IRestApiAccountActions AccountActions => _restApiAccountActions;
    public IRestApiAccountInfos AccountInfos => _restApiAccountInfos;
    public IRestApiPublicInfos PublicInfos => _restApiPublicInfos;

    public BvRestClient(
      string apiKey = "",
      string apiSecret = "",
      string url = "https://api.bitvavo.com/v2",
      TimeSpan? accessWindow = null
    ) {
      _accessWindow = accessWindow is TimeSpan validAccessWindow ? validAccessWindow : TimeSpan.FromSeconds(10);
      _apiKey = apiKey;
      _apiSecret = apiSecret;

      _restApiAccountActions = new RestApiAccountActions(this);
      _restApiAccountInfos = new RestApiAccountInfos(this);
      _restApiPublicInfos = new RestApiPublicInfos(this);
      _restClient = new RestClient(url);
    }

    private RestRequest CreateRequest(RestRequestOptions requestOptions) {
      string requestPath = requestOptions.ApiPath.GetDescription();

      if (requestPath.HasText() && requestOptions.ApiPathMarket.HasText()) {
        requestPath = requestPath.Replace("market", requestOptions.ApiPathMarket);
      }

      string requestBodyAsJson = CreateRequestBody(requestOptions) is RestRequestBody requestBody
        ? JsonSerializer.Serialize(requestBody, JsonOptions)
        : string.Empty;

      RestRequest result = new RestRequest(requestPath, requestOptions.ApiMethod);
      CreateRequestParameters(result, requestOptions, requestBodyAsJson);

      if (requestOptions.AddSignature) {
        CreateRequestSignature(result, requestBodyAsJson);
      }

      return result;
    }

    private static RestRequestBody CreateRequestBody(RestRequestOptions requestOptions) {
      if (requestOptions.PlaceOrderOptions is AccountPlaceOrderOptions accountPlaceOrderOptions) {
        if (accountPlaceOrderOptions.LimitOptions is AccountPlaceOrderLimitOptions limitOptions) {
          return new RestRequestBody(
            amount: limitOptions.Amount,
            clientOrderId: limitOptions.ClientOrderId,
            market: requestOptions.Market,
            orderType: requestOptions.OrderType,
            postOnly: limitOptions.PostOnly,
            price: limitOptions.Price,
            responseRequired: limitOptions.ResponseRequired,
            selfTradePrevention: limitOptions.SelfTradePrevention,
            side: requestOptions.Side,
            timeInForce: limitOptions.TimeInForce,
            triggerAmount: accountPlaceOrderOptions.TriggerOptions?.TriggerAmount,
            triggerReference: accountPlaceOrderOptions.TriggerOptions?.TriggerReference,
            triggerType: accountPlaceOrderOptions.TriggerOptions?.TriggerType
          );
        }

        if (accountPlaceOrderOptions.MarketOptions is AccountPlaceOrderMarketOptions marketOptions) {
          return new RestRequestBody(
            amount: marketOptions.Amount,
            amountQuote: marketOptions.AmountQuote,
            clientOrderId: marketOptions.ClientOrderId,
            disableMarketProtection: marketOptions.DisableMarketProtection,
            market: requestOptions.Market,
            orderType: requestOptions.OrderType,
            responseRequired: marketOptions.ResponseRequired,
            selfTradePrevention: marketOptions.SelfTradePrevention,
            side: requestOptions.Side,
            triggerAmount: accountPlaceOrderOptions.TriggerOptions?.TriggerAmount,
            triggerReference: requestOptions.PlaceOrderOptions.TriggerOptions?.TriggerReference,
            triggerType: accountPlaceOrderOptions.TriggerOptions?.TriggerType
          );
        }
      }

      if (requestOptions.UpdateOrderOptions is AccountUpdateOrderOptions accountUpdateOrderOptions) {
        if (accountUpdateOrderOptions.LimitOptions is AccountUpdateOrderLimitOptions limitOptions) {
          return new RestRequestBody(
            amount: limitOptions.Amount,
            amountRemaining: limitOptions.AmountRemaining,
            clientOrderId: requestOptions.ClientOrderId,
            market: requestOptions.Market,
            orderId: requestOptions.OrderId,
            postOnly: limitOptions.PostOnly,
            price: limitOptions.Price,
            responseRequired: limitOptions.ResponseRequired,
            selfTradePrevention: limitOptions.SelfTradePrevention,
            timeInForce: limitOptions.TimeInForce,
            triggerAmount: accountUpdateOrderOptions.TriggerOptions?.TriggerAmount,
            triggerReference: accountUpdateOrderOptions.TriggerOptions?.TriggerReference,
            triggerType: accountUpdateOrderOptions.TriggerOptions?.TriggerType
          );
        }

        if (accountUpdateOrderOptions.MarketOptions is AccountUpdateOrderMarketOptions marketOptions) {
          return new RestRequestBody(
            amount: marketOptions.Amount,
            amountQuote: marketOptions.AmountQuote,
            amountRemaining: marketOptions.AmountRemaining,
            clientOrderId: requestOptions.ClientOrderId,
            disableMarketProtection: marketOptions.DisableMarketProtection,
            market: requestOptions.Market,
            orderId: requestOptions.OrderId,
            responseRequired: marketOptions.ResponseRequired,
            selfTradePrevention: marketOptions.SelfTradePrevention,
            triggerAmount: accountUpdateOrderOptions.TriggerOptions?.TriggerAmount,
            triggerReference: accountUpdateOrderOptions.TriggerOptions?.TriggerReference,
            triggerType: accountUpdateOrderOptions.TriggerOptions?.TriggerType
          );
        }
      }

      if (requestOptions.Withdrawal is AccountWithdrawal accountWithdrawal) {
        return new RestRequestBody(
          address: accountWithdrawal.Address,
          addWithdrawalFee: accountWithdrawal.AddWithdrawalFee,
          amount: accountWithdrawal.Amount,
          paymentId: accountWithdrawal.PaymentId,
          symbol: accountWithdrawal.Symbol
        );
      }

      return null;
    }

    private static void CreateRequestParameters(RestRequest request, RestRequestOptions requestOptions, string body) {
      if (body.HasText()) {
        request.AddParameter(name: "application/json", value: body, type: ParameterType.RequestBody);
        return;
      }

      if (requestOptions.Base.HasText()) {
        request.AddParameter(name: "base", value: requestOptions.Base);
      }

      if (requestOptions.ClientOrderId.HasText()) {
        request.AddParameter(name: "clientOrderId", value: requestOptions.ClientOrderId);
      }

      if (requestOptions.Depth is int validDepth) {
        request.AddParameter(name: "depth", value: Math.Max(1, validDepth));
      }

      if (requestOptions.End is DateTime validEnd) {
        request.AddParameter(name: "end", value: validEnd.ToUnixTimeMilliseconds());
      }

      if (requestOptions.FromDate is DateTime validFromDate) {
        request.AddParameter(name: "fromDate", value: validFromDate.ToUnixTimeMilliseconds());
      }

      if (requestOptions.Interval is MarketInterval validInterval) {
        request.AddParameter(name: "interval", value: validInterval.GetDescription());
      }

      if (requestOptions.Limit is int validLimit) {
        request.AddParameter(name: "limit", value: Math.Min(Math.Max(validLimit, 1), 1000));
      }

      if (requestOptions.Market.HasText()) {
        request.AddParameter(name: "market", value: requestOptions.Market);
      }

      if (requestOptions.MaxItems is int validMaxItems) {
        request.AddParameter(name: "maxItems", value: Math.Min(Math.Max(validMaxItems, 1), 100));
      }

      if (requestOptions.OrderId is Guid validOrderId) {
        request.AddParameter(name: "orderId", value: validOrderId.ToString());
      }

      if (requestOptions.OrderIdFrom is Guid validOrderIdFrom) {
        request.AddParameter(name: "orderIdFrom", value: validOrderIdFrom.ToString());
      }

      if (requestOptions.OrderIdTo is Guid validOrderIdTo) {
        request.AddParameter(name: "orderIdTo", value: validOrderIdTo.ToString());
      }

      if (requestOptions.Page is int validPage) {
        request.AddParameter(name: "page", value: Math.Max(1, validPage));
      }

      if (requestOptions.Quote is FeeQuote validFeeQuote) {
        request.AddParameter(name: "quote", value: validFeeQuote.GetDescription());
      }

      if (requestOptions.Start is DateTime validStart) {
        request.AddParameter(name: "start", value: validStart.ToUnixTimeMilliseconds());
      }

      if (requestOptions.Symbol.HasText()) {
        request.AddParameter(name: "symbol", value: requestOptions.Symbol);
      }

      if (requestOptions.ToDate is DateTime validToDate) {
        request.AddParameter(name: "toDate", value: validToDate.ToUnixTimeMilliseconds());
      }

      if (requestOptions.TradeIdFrom is Guid validTradeIdFrom) {
        request.AddParameter(name: "tradeIdFrom", value: validTradeIdFrom.ToString());
      }

      if (requestOptions.TradeIdTo is Guid validTradeIdTo) {
        request.AddParameter(name: "tradeIdTo", value: validTradeIdTo.ToString());
      }

      if (requestOptions.TransactionType is AccountTransactionType validTransactionType) {
        request.AddParameter(name: "type", value: validTransactionType.GetDescription());
      }
    }

    private void CreateRequestSignature(RestRequest request, string body) {
      long unixTimeInMs = DateTime.UtcNow.ToUnixTimeMilliseconds();
      string requestMethod = request.Method.ToString().ToUpper();
      string uriPathAndQuery = _restClient.BuildUri(request).PathAndQuery;
      string signaturePayload = unixTimeInMs + requestMethod + uriPathAndQuery + body;

      ASCIIEncoding asciiEncoding = new ASCIIEncoding();
      HMACSHA256 hmacSha256 = new HMACSHA256(asciiEncoding.GetBytes(_apiSecret));
      byte[] hash = hmacSha256.ComputeHash(asciiEncoding.GetBytes(signaturePayload));
      string signature = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();

      request.AddHeader(name: "Bitvavo-Access-Key", value: _apiKey);
      request.AddHeader(name: "Bitvavo-Access-Signature", value: signature);
      request.AddHeader(name: "Bitvavo-Access-Timestamp", value: unixTimeInMs);
      request.AddHeader(name: "Bitvavo-Access-Window", value: (int)_accessWindow.TotalMilliseconds);
    }

    public Response<T> SendRequest<T>(RestRequestOptions requestOptions) where T : class {
      RestRequest request = CreateRequest(requestOptions);
      RestResponse<T> response = _restClient.Execute<T>(request);

      return Response<T>.GetResponse(response);
    }

    public async Task<Response<T>> SendRequestAsync<T>(RestRequestOptions requestOptions) where T : class {
      RestRequest request = CreateRequest(requestOptions);
      RestResponse<T> response = await _restClient.ExecuteAsync<T>(request);

      return Response<T>.GetResponse(response);
    }
  }
}