using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;
using tar.Bitvavo.Api.Extensions;
using tar.Bitvavo.Api.RestApi.Requests;
using tar.Bitvavo.Api.RestApi.Responses;
using tar.Bitvavo.Api.WebSocketApi;
using tar.Bitvavo.Api.WebSocketApi.Receives;
using tar.Bitvavo.Api.WebSocketApi.Sends;
using tar.Bitvavo.Extensions;
using tar.WebSocket;

namespace tar.Bitvavo.Api {
  public class BvWebSocketClient {
    private readonly TimeSpan _accessWindow;
    private readonly string _apiKey;
    private readonly string _apiSecret;
    private DateTime? _lastAuthed;
    private readonly WebSocketClient _webSocketClient;
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly string _url;
    private readonly WebSocketAccountActions _webSocketAccountActions;
    private readonly WebSocketAccountInfos _webSocketAccountInfos;
    private readonly WebSocketPublicInfos _webSocketPublicInfos;
    private readonly WebSocketSubscriptions _webSocketSubscriptions;

    public IWebSocketAccountActions AccountActions => _webSocketAccountActions;
    public IWebSocketAccountInfos AccountInfos => _webSocketAccountInfos;
    public IWebSocketPublicInfos PublicInfos => _webSocketPublicInfos;
    public IWebSocketSubscriptions Subscriptions => _webSocketSubscriptions;

    public delegate void OnClosingDelegate(CallbackInfo info);
    public delegate void OnConnectingDelegate(CallbackInfo info);
    public delegate void OnMessageReceivedDelegate(CallbackInfo info);
    public delegate void OnMessageSentDelegate(CallbackInfo info);
    public delegate void OnStateChangedDelegate(CallbackInfo info);
    public event OnClosingDelegate OnClosing;
    public event OnConnectingDelegate OnConnecting;
    public event OnMessageReceivedDelegate OnMessageReceived;
    public event OnMessageSentDelegate OnMessageSent;
    public event OnStateChangedDelegate OnStateChanged;

    public BvWebSocketClient(
      TimeSpan? accessWindow = null,
      string apiKey = "",
      string apiSecret = "",
      TimeSpan? keepAliveInterval = null,
      string url = "wss://ws.bitvavo.com/v2/"
    ) {
      _accessWindow = accessWindow is TimeSpan validAccessWindow ? validAccessWindow : TimeSpan.FromSeconds(10);
      _apiKey = apiKey;
      _apiSecret = apiSecret;
      _url = url;

      _jsonOptions = new JsonSerializerOptions() {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
      };

      _webSocketAccountActions = new WebSocketAccountActions(this);
      _webSocketAccountInfos = new WebSocketAccountInfos(this);
      _webSocketPublicInfos = new WebSocketPublicInfos(this);
      _webSocketSubscriptions = new WebSocketSubscriptions(this);

      _webSocketClient = new WebSocketClient(
        options: new WebSocketClientOptions() {
          KeepAliveInterval = keepAliveInterval is TimeSpan validKeepAliveInterval
            ? validKeepAliveInterval
            : TimeSpan.FromSeconds(5)
        },
        url: url
      );

      _webSocketClient.OnAction += OnWebSocketClientAction;
    }

    public async Task AuthenticateAsync(long? requestId = null) {
      long unixTimeInMs = DateTime.UtcNow.ToUnixTimeMilliseconds();
      string uriPathAndQuery = new Uri(_url).PathAndQuery;
      string signaturePayload = unixTimeInMs + "GET" + uriPathAndQuery + "websocket";

      ASCIIEncoding asciiEncoding = new ASCIIEncoding();
      HMACSHA256 hmacSha256 = new HMACSHA256(asciiEncoding.GetBytes(_apiSecret));
      byte[] hash = hmacSha256.ComputeHash(asciiEncoding.GetBytes(signaturePayload));
      string signature = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();

      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.Authenticate,
        key: _apiKey,
        requestId: requestId,
        signature: signature,
        timestamp: unixTimeInMs,
        window: (int)_accessWindow.TotalMilliseconds
      );

      await SendAsync(sendOptions);
    }

    public async Task CloseAsync() => await _webSocketClient.CloseAsync();

    public async Task ConnectAsync() => await _webSocketClient.ConnectAsync();

    private static SendPayload CreateSendPayload(SendOptions sendOptions) {
      if (sendOptions.PlaceOrderOptions is AccountPlaceOrderOptions accountPlaceOrderOptions) {
        if (accountPlaceOrderOptions.LimitOptions is AccountPlaceOrderLimitOptions limitOptions) {
          return new SendPayload(
            action: sendOptions.Action,
            amount: limitOptions.Amount,
            clientOrderId: limitOptions.ClientOrderId,
            market: sendOptions.Market,
            orderType: sendOptions.OrderType,
            postOnly: limitOptions.PostOnly,
            price: limitOptions.Price,
            requestId: sendOptions.RequestId,
            responseRequired: limitOptions.ResponseRequired,
            selfTradePrevention: limitOptions.SelfTradePrevention,
            side: sendOptions.Side,
            timeInForce: limitOptions.TimeInForce,
            triggerAmount: accountPlaceOrderOptions.TriggerOptions?.TriggerAmount,
            triggerReference: accountPlaceOrderOptions.TriggerOptions?.TriggerReference,
            triggerType: accountPlaceOrderOptions.TriggerOptions?.TriggerType
          );
        }

        if (accountPlaceOrderOptions.MarketOptions is AccountPlaceOrderMarketOptions marketOptions) {
          return new SendPayload(
            action: sendOptions.Action,
            amount: marketOptions.Amount,
            amountQuote: marketOptions.AmountQuote,
            clientOrderId: marketOptions.ClientOrderId,
            disableMarketProtection: marketOptions.DisableMarketProtection,
            market: sendOptions.Market,
            orderType: sendOptions.OrderType,
            requestId: sendOptions.RequestId,
            responseRequired: marketOptions.ResponseRequired,
            selfTradePrevention: marketOptions.SelfTradePrevention,
            side: sendOptions.Side,
            timeInForce: marketOptions.TimeInForce,
            triggerAmount: accountPlaceOrderOptions.TriggerOptions?.TriggerAmount,
            triggerReference: sendOptions.PlaceOrderOptions.TriggerOptions?.TriggerReference,
            triggerType: accountPlaceOrderOptions.TriggerOptions?.TriggerType
          );
        }
      }

      if (sendOptions.UpdateOrderOptions is AccountUpdateOrderOptions accountUpdateOrderOptions) {
        if (accountUpdateOrderOptions.LimitOptions is AccountUpdateOrderLimitOptions limitOptions) {
          return new SendPayload(
            action: sendOptions.Action,
            amount: limitOptions.Amount,
            amountRemaining: limitOptions.AmountRemaining,
            clientOrderId: sendOptions.OrderIdIsClientOrderId ? sendOptions.OrderId : null,
            market: sendOptions.Market,
            orderId: sendOptions.OrderIdIsClientOrderId ? null : sendOptions.OrderId,
            postOnly: limitOptions.PostOnly,
            price: limitOptions.Price,
            requestId: sendOptions.RequestId,
            responseRequired: limitOptions.ResponseRequired,
            selfTradePrevention: limitOptions.SelfTradePrevention,
            timeInForce: limitOptions.TimeInForce,
            triggerAmount: accountUpdateOrderOptions.TriggerOptions?.TriggerAmount,
            triggerReference: accountUpdateOrderOptions.TriggerOptions?.TriggerReference,
            triggerType: accountUpdateOrderOptions.TriggerOptions?.TriggerType
          );
        }

        if (accountUpdateOrderOptions.MarketOptions is AccountUpdateOrderMarketOptions marketOptions) {
          return new SendPayload(
            action: sendOptions.Action,
            amount: marketOptions.Amount,
            amountQuote: marketOptions.AmountQuote,
            amountRemaining: marketOptions.AmountRemaining,
            clientOrderId: sendOptions.OrderIdIsClientOrderId ? sendOptions.OrderId : null,
            disableMarketProtection: marketOptions.DisableMarketProtection,
            market: sendOptions.Market,
            orderId: sendOptions.OrderIdIsClientOrderId ? null : sendOptions.OrderId,
            requestId: sendOptions.RequestId,
            responseRequired: marketOptions.ResponseRequired,
            selfTradePrevention: marketOptions.SelfTradePrevention,
            timeInForce: marketOptions.TimeInForce,
            triggerAmount: accountUpdateOrderOptions.TriggerOptions?.TriggerAmount,
            triggerReference: accountUpdateOrderOptions.TriggerOptions?.TriggerReference,
            triggerType: accountUpdateOrderOptions.TriggerOptions?.TriggerType
          );
        }
      }

      if (sendOptions.Withdrawal is AccountWithdrawal accountWithdrawal) {
        return new SendPayload(
          action: sendOptions.Action,
          address: accountWithdrawal.Address,
          addWithdrawalFee: accountWithdrawal.AddWithdrawalFee,
          amount: accountWithdrawal.Amount,
          paymentId: accountWithdrawal.PaymentId,
          requestId: sendOptions.RequestId,
          symbol: accountWithdrawal.Symbol
        );
      }

      int? depth = null;
      int? limit = null;
      int? maxItems = null;
      int? page = null;

      if (sendOptions.Depth.HasValue && sendOptions.Depth > 0) {
        depth = Math.Max(1, ((int)sendOptions.Depth));
      }

      if (sendOptions.Limit.HasValue && sendOptions.Limit > 0) {
        limit = Math.Max(Math.Min(((int)sendOptions.Limit), 1), 1000);
      }

      if (sendOptions.MaxItems.HasValue && sendOptions.MaxItems > 0) {
        maxItems = Math.Max(Math.Min(((int)sendOptions.MaxItems), 1), 100);
      }

      if (sendOptions.Page.HasValue && sendOptions.Page > 0) {
        page = Math.Max(1, ((int)sendOptions.Page));
      }

      return new SendPayload(
        action: sendOptions.Action,
        @base: sendOptions.Base,
        channels: sendOptions.Channels,
        clientOrderId: sendOptions.OrderIdIsClientOrderId ? sendOptions.OrderId : null,
        depth: depth,
        end: sendOptions.End,
        fromDate: sendOptions.FromDate,
        interval: sendOptions.Interval,
        key: sendOptions.Key,
        limit: limit,
        market: sendOptions.Market,
        maxItems: maxItems,
        orderId: sendOptions.OrderIdIsClientOrderId ? null : sendOptions.OrderId,
        orderIdFrom: sendOptions.OrderIdFrom,
        orderIdTo: sendOptions.OrderIdTo,
        page: page,
        quote: sendOptions.Quote,
        requestId: sendOptions.RequestId,
        signature: sendOptions.Signature,
        start: sendOptions.Start,
        symbol: sendOptions.Symbol,
        timestamp: sendOptions.Timestamp,
        toDate: sendOptions.ToDate,
        tradeIdFrom: sendOptions.TradeIdFrom,
        tradeIdTo: sendOptions.TradeIdTo,
        type: sendOptions.TransactionType,
        window: sendOptions.Window
      );
    }

    private ReceiveMessage MapReceivedMessage(JsonObject jsonObject) {
      ReceiveMessage result = new ReceiveMessage();

      if (jsonObject["error"] is JsonNode errorNode) {
        result.Error = errorNode.ToString();
      }

      if (
        jsonObject["errorCode"] is JsonNode errorCodeNode
        && int.TryParse(errorCodeNode.ToString(), out int errorCode)
      ) {
        result.ErrorCode = errorCode;
      }

      if (
        jsonObject["requestId"] is JsonNode requestIdNode
        && long.TryParse(requestIdNode.ToString(), out long requestId)
      ) {
        result.RequestId = requestId;
      }

      if (jsonObject["action"] is JsonNode actionNode) {
        result.Action = actionNode.ToString().ToEnumByDescription<WebSocketAction>();

        if (jsonObject["response"] is JsonArray responseArray) {
          result.Data = new ReceiveMessageData();

          switch (result.Action) {
            case WebSocketAction.AccountCancelOrders:
              result.Data.AccountCancelOrders = responseArray.Deserialize<List<AccountCancelOrderResponse>>(_jsonOptions);
              break;

            case WebSocketAction.GetAccountBalance:
              result.Data.AccountBalance = responseArray.Deserialize<List<AccountBalanceResponse>>(_jsonOptions);
              break;

            case WebSocketAction.GetMarketAssets:
              result.Data.MarketAssets = responseArray.Deserialize<List<MarketAssetResponse>>(_jsonOptions);
              break;

            case WebSocketAction.GetAccountDepositHistory:
              result.Data.AccountDepositHistory = responseArray.Deserialize<List<AccountDepositHistoryResponse>>(_jsonOptions);
              break;

            case WebSocketAction.GetMarketCandles:
              result.Data.MarketCandles = responseArray.Deserialize<List<MarketCandlesResponse>>(_jsonOptions);
              break;

            case WebSocketAction.GetMarkets:
              result.Data.Markets = responseArray.Deserialize<List<MarketResponse>>(_jsonOptions);
              break;

            case WebSocketAction.GetMarketTicker24h:
              result.Data.MarketsTicker24h = responseArray.Deserialize<List<MarketTicker24hResponse>>(_jsonOptions);
              break;

            case WebSocketAction.GetMarketTickerBook:
              result.Data.MarketsTickerBook = responseArray.Deserialize<List<MarketTickerBookResponse>>(_jsonOptions);
              break;

            case WebSocketAction.GetMarketTickerPrice:
              result.Data.MarketsTickerPrice = responseArray.Deserialize<List<MarketTickerPriceResponse>>(_jsonOptions);
              break;

            case WebSocketAction.GetMarketTrades:
              result.Data.MarketTrades = responseArray.Deserialize<List<MarketTradesResponse>>(_jsonOptions);
              break;

            case WebSocketAction.GetAccountOpenOrders:
            case WebSocketAction.GetAccountOrders:
            case WebSocketAction.AccountPlaceOrder:
            case WebSocketAction.AccountUpdateOrder:
              result.Data.AccountOrders = responseArray.Deserialize<List<AccountOrderResponse>>(_jsonOptions);
              break;

            case WebSocketAction.GetAccountTrades:
              result.Data.AccountTrades = responseArray.Deserialize<List<AccountTradeResponse>>(_jsonOptions);
              break;

            case WebSocketAction.GetAccountWithdrawalHistory:
              result.Data.AccountWithdrawalHistory = responseArray.Deserialize<List<AccountWithdrawalHistoryResponse>>(_jsonOptions);
              break;
          }
        }

        if (jsonObject["response"] is JsonObject responseObject) {
          result.Data = new ReceiveMessageData();

          switch (result.Action) {
            case WebSocketAction.AccountCancelOrder:
              result.Data.AccountCancelOrder = responseObject.Deserialize<AccountCancelOrderResponse>(_jsonOptions);
              break;

            case WebSocketAction.GetAccount:
              result.Data.Account = responseObject.Deserialize<AccountResponse>(_jsonOptions);
              break;

            case WebSocketAction.GetAccountFees:
              result.Data.AccountFees = responseObject.Deserialize<AccountFeesResponse>(_jsonOptions);
              break;

            case WebSocketAction.GetAccountTransactionHistory:
              result.Data.AccountTransactionHistory = responseObject.Deserialize<AccountTransactionHistoryResponse>(_jsonOptions);
              break;

            case WebSocketAction.GetMarketAssets:
              result.Data.MarketAsset = responseObject.Deserialize<MarketAssetResponse>(_jsonOptions);
              break;

            case WebSocketAction.GetAccountDepositAddress:
              result.Data.AccountDepositAddress = responseObject.Deserialize<AccountDepositAddressResponse>(_jsonOptions);
              break;

            case WebSocketAction.GetMarketOrderBook:
              result.Data.MarketOrderBook = responseObject.Deserialize<MarketOrderBookResponse>(_jsonOptions);
              break;

            case WebSocketAction.GetMarkets:
              result.Data.Market = responseObject.Deserialize<MarketResponse>(_jsonOptions);
              break;

            case WebSocketAction.GetMarketTicker24h:
              result.Data.MarketTicker24h = responseObject.Deserialize<MarketTicker24hResponse>(_jsonOptions);
              break;

            case WebSocketAction.GetMarketTickerBook:
              result.Data.MarketTickerBook = responseObject.Deserialize<MarketTickerBookResponse>(_jsonOptions);
              break;

            case WebSocketAction.GetMarketTickerPrice:
              result.Data.MarketTickerPrice = responseObject.Deserialize<MarketTickerPriceResponse>(_jsonOptions);
              break;

            case WebSocketAction.GetAccountOrder:
              result.Data.AccountOrder = responseObject.Deserialize<AccountOrderResponse>(_jsonOptions);
              break;

            case WebSocketAction.GetServerTime:
              result.Data.ServerTime = responseObject.Deserialize<ServerTimeResponse>(_jsonOptions);
              break;

            case WebSocketAction.AccountWithdrawAssets:
              result.Data.AccountWithdrawAsset = responseObject.Deserialize<AccountWithdrawAssetResponse>(_jsonOptions);
              break;
          }
        }
      }

      if (jsonObject["event"] is JsonNode eventNode) {
        result.Event = eventNode.ToString().ToEnumByDescription<WebSocketEvent>();

        switch (result.Event) {
          case WebSocketEvent.Authenticate:
            if (
              jsonObject["authenticated"] is JsonNode authenticatedNode
              && bool.TryParse(authenticatedNode.ToString(), out bool authenticated)
            ) {
              result.Authenticated = authenticated;

              if (authenticated) {
                _lastAuthed = DateTime.UtcNow;
              }
            }
            break;

          case WebSocketEvent.Book:
            result.SubscriptionData = new ReceiveMessageSubscriptionData() {
              MarketOrderBook = jsonObject.Deserialize<ReceiveSubscriptionMarketOrderBook>(_jsonOptions)
            };
            break;

          case WebSocketEvent.Candle:
            if (
              jsonObject["candle"] is JsonArray candle
              && jsonObject["interval"] is JsonNode intervalNode
              && jsonObject["market"] is JsonNode marketNode
            ) {
              result.SubscriptionData = new ReceiveMessageSubscriptionData() {
                MarketCandles = new List<ReceiveSubscriptionMarketCandle>()
              };

              foreach (JsonArray candleValues in candle.Cast<JsonArray>()) {
                long? timestamp = null;

                if (candleValues[0]?.ToString() is string timestampString) {
                  timestamp = long.Parse(timestampString, NumberStyles.Any, CultureInfo.InvariantCulture);
                }

                result.SubscriptionData.MarketCandles.Add(
                  new ReceiveSubscriptionMarketCandle() {
                    Close = candleValues[4]?.ToString().ToDecimalOrNull(),
                    High = candleValues[2]?.ToString().ToDecimalOrNull(),
                    Interval = intervalNode.ToString().ToEnumByDescription<MarketInterval>(),
                    Low = candleValues[3]?.ToString().ToDecimalOrNull(),
                    Market = marketNode.ToString(),
                    Open = candleValues[1]?.ToString().ToDecimalOrNull(),
                    Timestamp = timestamp?.ToDateTimeFromUnixTimeMilliseconds(),
                    Volume = candleValues[5]?.ToString().ToDecimalOrNull()
                  }
                );
              }
            }
            break;

          case WebSocketEvent.Fill:
            result.SubscriptionData = new ReceiveMessageSubscriptionData() {
              AccountOrderFill = jsonObject.Deserialize<ReceiveSubscriptionAccountOrderFill>(_jsonOptions)
            };
            break;

          case WebSocketEvent.Order:
            result.SubscriptionData = new ReceiveMessageSubscriptionData() {
              AccountOrder = jsonObject.Deserialize<ReceiveSubscriptionAccountOrder>(_jsonOptions)
            };
            break;

          case WebSocketEvent.Subscribed:
            if (jsonObject["subscriptions"] is JsonObject subscriptionsObject) {
              result.Subscriptions = subscriptionsObject.Deserialize<ReceiveMessageSubscriptions>(_jsonOptions);
            }
            break;

          case WebSocketEvent.Ticker:
            result.SubscriptionData = new ReceiveMessageSubscriptionData() {
              MarketTicker = jsonObject.Deserialize<ReceiveSubscriptionMarketTicker>(_jsonOptions)
            };
            break;

          case WebSocketEvent.Ticker24h:
            if (jsonObject["data"] is JsonArray data) {
              result.SubscriptionData = new ReceiveMessageSubscriptionData() {
                MarketTicker24h = new List<ReceiveSubscriptionMarketTicker24h>()
              };

              foreach (JsonObject dataObject in data.Cast<JsonObject>()) {
                var ticker24hResponse = dataObject.Deserialize<ReceiveSubscriptionMarketTicker24h>(_jsonOptions);

                if (ticker24hResponse != null) {
                  result.SubscriptionData.MarketTicker24h.Add(ticker24hResponse);
                }
              }
            }
            break;

          case WebSocketEvent.Trade:
            result.SubscriptionData = new ReceiveMessageSubscriptionData() {
              MarketTrade = jsonObject.Deserialize<ReceiveSubscriptionMarketTrade>(_jsonOptions)
            };
            break;
        }
      }

      return result;
    }

    private void OnWebSocketClientAction(WebSocketClientInfo info) {
      ReceiveMessage receivedMessage = info.ReceivedMessage.HasText()
        && JsonSerializer.Deserialize<JsonObject>(info.ReceivedMessage) is JsonObject jsonObject
        ? MapReceivedMessage(jsonObject)
        : null;

      CallbackInfo callbackInfo = new CallbackInfo() {
        AccessWindow = _accessWindow,
        ClientAction = info.ClientAction,
        ClientActionDescription = info.ClientActionDescription,
        Closed = info.Closed,
        Duration = info.Duration,
        ErrorMessage = info.ErrorMessage,
        LastAuthed = _lastAuthed,
        Opened = info.Opened,
        ReceivedMessage = receivedMessage,
        SentMessage = info.SentMessage,
        SentOptions = (SendOptions)info.SentOptions,
        SentPayload = (SendPayload)info.SentPayload,
        State = info.State,
        StateDescription = info.StateDescription,
        Success = info.Success,
        Timestamp = info.Timestamp,
        TriggeredByClient = info.TriggeredByClient,
        Url = info.Url,
      };

      switch (info.ClientAction) {
        case WebSocketClientAction.Closing: OnClosing?.Invoke(callbackInfo); break;
        case WebSocketClientAction.Connecting: OnConnecting?.Invoke(callbackInfo); break;
        case WebSocketClientAction.MessageReceived: OnMessageReceived?.Invoke(callbackInfo); break;
        case WebSocketClientAction.MessageSent: OnMessageSent?.Invoke(callbackInfo); break;
        case WebSocketClientAction.StateChanged: OnStateChanged?.Invoke(callbackInfo); break;
      }
    }

    public async Task SendAsync(SendOptions sendOptions) {
      if (sendOptions.AuthRequired) {
        DateTime now = DateTime.UtcNow;

        if (_lastAuthed is null || _lastAuthed + _accessWindow < now) {
          await AuthenticateAsync();

          while (_lastAuthed is null || _lastAuthed < now || DateTime.UtcNow > now.AddSeconds(3)) {
            await Task.Delay(25);
          }
        }
      }

      SendPayload payload = CreateSendPayload(sendOptions);
      string payloadJson = JsonSerializer.Serialize(payload, _jsonOptions);

      await _webSocketClient.SendAsync(payloadJson);
    }
  }
}