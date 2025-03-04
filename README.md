# tar.Bitvavo.Api

![](https://img.shields.io/nuget/dt/tar.Bitvavo.Api) [![](https://img.shields.io/nuget/v/tar.Bitvavo.Api)](https://www.nuget.org/packages/tar.Bitvavo.Api)

Full [Bitvavo](https://www.bitvavo.com) API with REST and WebSocket functionality.

 - [X] C# .NET Standard v2.0
 - [X] Nuget Package: https://www.nuget.org/packages/tar.Bitvavo.Api

## Function

This library provides the functionalities of the [Bitvavo API for REST and WebSocket (2.5.0)](https://docs.bitvavo.com).

Additionally it automatically

- authenticates via web socket, if needed
- converts JSON strings to mapped objects
- converts internally used Unix timestamps to the human readable date time format
- converts internally used number strings to real decimal numbers
- converts internally used enum strings to real enums
- provides additional and directly accessable useful informations in every response

## Usage

```cs
BvRestClient bvRestClient = new(
  accessWindow: TimeSpan.FromSeconds(10),
  apiKey: yourApiKey,
  apiSecret: yourApiSecret,
  url: "https://api.bitvavo.com/v2"
);

BvWebSocketClient bvWebSocketClient = new(
  accessWindow: TimeSpan.FromSeconds(10),
  apiKey: yourApiKey,
  apiSecret: yourApiSecret,
  keepAliveInterval: TimeSpan.FromSeconds(5),
  url: "wss://ws.bitvavo.com/v2/"
);
```

All parameters are optional:
- `accessWindow`: time window for each request that requires authentification
- `apiKey` & `apiSecret`: are not required for public API endpoints but recommended for better rate limits/lock times
- `keepAliveInterval`: the web sockets heartbeat between client and server
- `url`: API base URL

### REST Methods

You can use the main methods of the rest client directly:

```cs
// for direct rest request usage you need to forward the expected response type <T>
var response1 = bvRestClient.SendRequest<T>(RestRequestOptions requestOptions);
var response2 = await bvRestClient.SendRequestAsync<T>(RestRequestOptions requestOptions);
```

But I recommend using the prepared methods which already have the correct parameters and response types set:

```cs
// account actions
var cancelOrderResponse = await bvRestClient.AccountActions.CancelOrderAsync(...);
var cancelOrdersResponse = await bvRestClient.AccountActions.CancelOrdersAsync(...);
var placeLimitOrderResponse = await bvRestClient.AccountActions.PlaceLimitOrderAsync(...);
var placeMarketOrderResponse = await bvRestClient.AccountActions.PlaceMarketOrderAsync(...);
var placeStopLossLimitOrderResponse = await bvRestClient.AccountActions.PlaceStopLossLimitOrderAsync(...);
var placeStopLossOrderResponse = await bvRestClient.AccountActions.PlaceStopLossOrderAsync(...);
var placeTakeProfitLimitOrderResponse = await bvRestClient.AccountActions.PlaceTakeProfitLimitOrderAsync(...);
// etc.

// account infos
var balance = await bvRestClient.AccountInfos.GetBalanceAsync();
var deposits = await bvRestClient.AccountInfos.GetDepositHistoryAsync();
// etc.

// public infos
var asset = await bvRestClient.PublicInfos.GetAssetAsync(symbol);
var assets = await bvRestClient.PublicInfos.GetAssetsAsync();
var candles = await bvRestClient.PublicInfos.GetCandlesAsync(market, interval, limit, start, end);
var market = await bvRestClient.PublicInfos.GetMarketAsync(market);
var markets = await bvRestClient.PublicInfos.GetMarketsAsync();
// etc.
```

Account methods need authentication for which a valid API key & secret needs to be provided.

The returned `Response<T>` class contains all necessary information:

- `Data`: the response message as mapped object of type `<T>`
- `Error`: Bitvavo error description
- `ErrorCode`: Bitvavo error code
- `IsSuccessful`: indicator if the request was successful
- `IsSuccessStatusCode`: if the http status code is a success status
- `JsonContent`: the response message as json string
- `RateLimit`: the current Bitvavo rate limit
- `RateLimitRemaining`: your remaining rate limit points
- `RateLimitResetAt`: the timestamp when the rate limit is reset at
- `Request`: the original request
- `ResponseUri`: the uri you get the response from
- `Server`: server description
- `StatusCode`: the http status code
- `StatusDescription`: description of the http status code
- `Version`: the http version

### Web Socket Methods

You can use the main methods of the web socket client directly:

```cs
await bvWebSocketClient.AuthenticateAsync(long? requestId = null);
await bvWebSocketClient.ConnectAsync();
await bvWebSocketClient.CloseAsync();
await bvWebSocketClient.SendAsync(SendOptions sendOptions);
```

But I recommend using the prepared methods which already have the correct parameters and response types set.

The same methods as for REST are provided. Additionally, you can use subscription methods:

```cs
// account actions
await bvWebSocketClient.AccountActions.CancelOrderAsync(...);
// etc.

// account infos
await bvWebSocketClient.AccountInfos.GetBalanceAsync();
// etc.

// public infos
var asset = await bvWebSocketClient.PublicInfos.GetAssetAsync(symbol);
// etc.

// subscriptions
await bvWebSocketClient.Subscriptions.SubscribeToAccountOrdersAsync();
await bvWebSocketClient.Subscriptions.SubscribeToAccountOrdersAsync(markets);
await bvWebSocketClient.Subscriptions.SubscribeToMarketCandlesAsync(markets, intervals);
await bvWebSocketClient.Subscriptions.SubscribeToMarketOrderBookAsync(markets);
await bvWebSocketClient.Subscriptions.SubscribeToMarketTicker24hAsync(markets);
await bvWebSocketClient.Subscriptions.SubscribeToMarketTickerAsync(markets);
await bvWebSocketClient.Subscriptions.SubscribeToMarketTradesAsync(markets);
await bvWebSocketClient.Subscriptions.UnsubscribeFromAccountOrdersAsync(markets);
await bvWebSocketClient.Subscriptions.UnsubscribeFromMarketCandlesAsync(markets, intervals);
await bvWebSocketClient.Subscriptions.UnsubscribeFromMarketOrderBookAsync(markets);
await bvWebSocketClient.Subscriptions.UnsubscribeFromMarketTicker24hAsync(markets);
await bvWebSocketClient.Subscriptions.UnsubscribeFromMarketTickerAsync(markets);
await bvWebSocketClient.Subscriptions.UnsubscribeFromMarketTradesAsync(markets);
```

Account methods need authentication for which a valid API key & secret needs to be provided. The authentication is done automatically beforehand, if necessary. Therefore it is checked if the last authentication is still valid, depending on the access window.

You are also able to set an additional `requestId` parameter on each method which you will get back in the corresponding received message.

### Web Socket Events

To receive web socket updates, you need to add event handlers for the corresponding web socket events and subscribe them.

For example:

```cs
// subscribe to events
bvWebSocketClient.OnClosing += BvWebSocketClient_OnClosing;
bvWebSocketClient.OnConnecting += BvWebSocketClient_OnConnecting;
bvWebSocketClient.OnMessageReceived += BvWebSocketClient_OnMessageReceived;
bvWebSocketClient.OnMessageSent += BvWebSocketClient_OnMessageSent;
bvWebSocketClient.OnStateChanged += BvWebSocketClient_OnStateChanged;

// your explicit event handler method where you handle on closing events
private void BvWebSocketClient_OnClosing(CallbackInfo info) {
  MessageBox.Show(
    info.Success
      ? "Connection closed"
      : $"Connection not closed: {info.ErrorMessage}"
  );
}

// your explicit event handler method where you handle on message received events
private void BvWebSocketClient_OnMessageReceived(CallbackInfo info) {
  // ...
}

// etc.
```

The returned `CallbackInfo` class contains all necessary information:

- `AccessWindow`: the accessable time for authenticated requests
- `ClientAction`: action which triggered the callback
- `ClientActionDescription`: action as text
- `Closed`: last closed timestamp
- `Duration`: time the web socket is/was open
- `ErrorMessage`: description when an error occured
- `LastAuthed`: last authentication timestamp
- `Opened`: last opened timestamp
- `ReceivedMessage`: received message info
  - `Action`: the basic api method/endpoint used
  - `Authenticated`: authentication indicator
  - `Data`: the received message data as mapped objects
  - `Error`: Bitvavo error description
  - `ErrorCode`: Bitvavo error code
  - `Event`: base Bitvavo endpoint event
  - `SubscriptionData`: the received subscription data as mapped objects
  - `Subscriptions`: subscribed channels
  - `RequestId`: the optional `requestId` you have set
- `SentMessage`: sent message as JSON string
- `SentOptions`: options used to generate the send payload
- `SentPayload`: send message as mapped object
- `State`: the current state of the internal ClientWebSocket
- `StateDescription`: state as text
- `Success`: if the action was successful
- `Timestamp`: when the action occured
- `TriggeredByClient`: if the action was triggered by the client (you), otherwise by the server
- `Url`: the URL the web socket is connected to

The provided information depends on the actual client action.