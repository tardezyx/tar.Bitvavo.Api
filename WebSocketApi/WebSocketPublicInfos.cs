using System;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;
using tar.Bitvavo.Api.WebSocketApi.Sends;

namespace tar.Bitvavo.Api.WebSocketApi {
  internal class WebSocketPublicInfos : IWebSocketPublicInfos {
    private readonly BvWebSocketClient _webSocket;

    public WebSocketPublicInfos(BvWebSocketClient webSocket) {
      _webSocket = webSocket;
    }

    public async Task GetAssetAsync(string symbol, long? requestId = null) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetMarketAssets,
        requestId: requestId,
        symbol: symbol
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetAssetsAsync(long? requestId = null) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetMarketAssets,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetCandlesAsync(
      string market,
      MarketInterval interval = MarketInterval._4h,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetMarketCandles,
        market: market,
        end: end,
        interval: interval,
        limit: limit,
        requestId: requestId,
        start: start
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetMarketAsync(string market, long? requestId = null) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetMarkets,
        market: market,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetMarketsAsync(long? requestId = null) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetMarkets,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetOrderBookAsync(
      string market,
      int? depth = null,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetMarketOrderBook,
        depth: depth,
        market: market,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetServerTimeAsync(long? requestId = null) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetServerTime,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetTicker24hAsync(string market, long? requestId = null) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetMarketTicker24h,
        market: market,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetTicker24hsAsync(long? requestId = null) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetMarketTicker24h,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetTickerBookAsync(string market, long? requestId = null) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetMarketTickerBook,
        market: market,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetTickerBooksAsync(long? requestId = null) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetMarketTickerBook,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetTickerPriceAsync(string market, long? requestId = null) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetMarketTickerPrice,
        market: market,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetTickerPricesAsync(long? requestId = null) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetMarketTickerPrice,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetTradesAsync(
      string market,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null,
      Guid? tradeIdFrom = null,
      Guid? tradeIdTo = null,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetMarketTrades,
        market: market,
        end: end,
        limit: limit,
        requestId: requestId,
        start: start,
        tradeIdFrom: tradeIdFrom,
        tradeIdTo: tradeIdTo
      );

      await _webSocket.SendAsync(sendOptions);
    }
  }
}