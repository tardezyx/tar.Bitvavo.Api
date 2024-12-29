using System.Collections.Generic;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;
using tar.Bitvavo.Api.RestApi.Requests;
using tar.Bitvavo.Api.WebSocketApi.Sends;
using tar.Bitvavo.Extensions;

namespace tar.Bitvavo.Api.WebSocketApi {
  internal class WebSocketSubscriptions : IWebSocketSubscriptions {
    private readonly BvWebSocketClient _webSocket;

    public WebSocketSubscriptions(BvWebSocketClient webSocket) {
      _webSocket = webSocket;
    }

    public async Task SubscribeToAccountOrdersAsync(
      List<string> markets,
      long? requestId = null
    ) {
      List<SubscriptionChannel> channels = new List<SubscriptionChannel>() {
        new SubscriptionChannel(
          markets: markets,
          name: SubscriptionChannelName.Account.GetDescription()
        )
      };

      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.Subscribe,
        authRequired: true,
        channels: channels,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task SubscribeToMarketOrderBookAsync(
      List<string> markets,
      long? requestId = null
    ) {
      List<SubscriptionChannel> channels = new List<SubscriptionChannel>() {
        new SubscriptionChannel(
          markets: markets,
          name: SubscriptionChannelName.Book.GetDescription()
        )
      };

      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.Subscribe,
        channels: channels,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task SubscribeToMarketCandlesAsync(
      List<string> markets,
      List<MarketInterval> intervals,
      long? requestId = null
    ) {
      List<string> channelIntervals = new List<string>();

      foreach (MarketInterval interval in intervals) {
        if (interval.GetDescription() is string intervalDescription) {
          channelIntervals.Add(intervalDescription);
        }
      }

      List<SubscriptionChannel> channels = new List<SubscriptionChannel>() {
        new SubscriptionChannel(
          interval: channelIntervals,
          markets: markets,
          name: SubscriptionChannelName.Candles.GetDescription()
        )
      };

      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.Subscribe,
        channels: channels,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task SubscribeToMarketTickerAsync(
      List<string> markets,
      long? requestId = null
    ) {
      List<SubscriptionChannel> channels = new List<SubscriptionChannel>() {
        new SubscriptionChannel(
          markets: markets,
          name: SubscriptionChannelName.Ticker.GetDescription()
        )
      };

      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.Subscribe,
        channels: channels,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task SubscribeToMarketTicker24hAsync(
      List<string> markets,
      long? requestId = null
    ) {
      List<SubscriptionChannel> channels = new List<SubscriptionChannel>() {
        new SubscriptionChannel(
          markets: markets,
          name: SubscriptionChannelName.Ticker24h.GetDescription()
        )
      };

      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.Subscribe,
        channels: channels,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task SubscribeToMarketTradesAsync(
      List<string> markets,
      long? requestId = null
    ) {
      List<SubscriptionChannel> channels = new List<SubscriptionChannel>() {
        new SubscriptionChannel(
          markets: markets,
          name: SubscriptionChannelName.Trades.GetDescription()
        )
      };

      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.Subscribe,
        channels: channels,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task UnsubscribeFromAccountOrdersAsync(
      List<string> markets,
      long? requestId = null
    ) {
      List<SubscriptionChannel> channels = new List<SubscriptionChannel>() {
        new SubscriptionChannel(
          markets: markets,
          name: SubscriptionChannelName.Account.GetDescription()
        )
      };

      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.Unsubscribe,
        authRequired: true,
        channels: channels,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task UnsubscribeFromMarketOrderBookAsync(
      List<string> markets,
      long? requestId = null
    ) {
      List<SubscriptionChannel> channels = new List<SubscriptionChannel>() {
        new SubscriptionChannel(
          markets: markets,
          name: SubscriptionChannelName.Book.GetDescription()
        )
      };

      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.Unsubscribe,
        channels: channels,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task UnsubscribeFromMarketCandlesAsync(
      List<string> markets,
      List<MarketInterval> intervals,
      long? requestId = null
    ) {
      List<string> channelIntervals = new List<string>();

      foreach (MarketInterval interval in intervals) {
        if (interval.GetDescription() is string intervalDescription) {
          channelIntervals.Add(intervalDescription);
        }
      }

      List<SubscriptionChannel> channels = new List<SubscriptionChannel>() {
        new SubscriptionChannel(
          interval: channelIntervals,
          markets: markets,
          name: SubscriptionChannelName.Candles.GetDescription()
        )
      };

      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.Unsubscribe,
        channels: channels,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task UnsubscribeFromMarketTickerAsync(
      List<string> markets,
      long? requestId = null
    ) {
      List<SubscriptionChannel> channels = new List<SubscriptionChannel>() {
        new SubscriptionChannel(
          markets: markets,
          name: SubscriptionChannelName.Ticker.GetDescription()
        )
      };

      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.Unsubscribe,
        channels: channels,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task UnsubscribeFromMarketTicker24hAsync(
      List<string> markets,
      long? requestId = null
    ) {
      List<SubscriptionChannel> channels = new List<SubscriptionChannel>() {
        new SubscriptionChannel(
          markets: markets,
          name: SubscriptionChannelName.Ticker24h.GetDescription()
        )
      };

      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.Unsubscribe,
        channels: channels,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task UnsubscribeFromMarketTradesAsync(
      List<string> markets,
      long? requestId = null
    ) {
      List<SubscriptionChannel> channels = new List<SubscriptionChannel>() {
        new SubscriptionChannel(
          markets: markets,
          name: SubscriptionChannelName.Trades.GetDescription()
        )
      };

      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.Unsubscribe,
        channels: channels,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }
  }
}