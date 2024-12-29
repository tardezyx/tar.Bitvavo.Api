using System;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.WebSocketApi {
  public interface IWebSocketPublicInfos {
    Task GetAssetAsync(string symbol, long? requestId = null);
    Task GetAssetsAsync(long? requestId = null);
    Task GetCandlesAsync(string market, MarketInterval interval = MarketInterval._4h, int? limit = null, DateTime? start = null, DateTime? end = null, long? requestId = null);
    Task GetMarketAsync(string market, long? requestId = null);
    Task GetMarketsAsync(long? requestId = null);
    Task GetOrderBookAsync(string market, int? depth = null, long? requestId = null);
    Task GetServerTimeAsync(long? requestId = null);
    Task GetTicker24hAsync(string market, long? requestId = null);
    Task GetTicker24hsAsync(long? requestId = null);
    Task GetTickerBookAsync(string market, long? requestId = null);
    Task GetTickerBooksAsync(long? requestId = null);
    Task GetTickerPriceAsync(string market, long? requestId = null);
    Task GetTickerPricesAsync(long? requestId = null);
    Task GetTradesAsync(string market, int? limit = null, DateTime? start = null, DateTime? end = null, Guid? tradeIdFrom = null, Guid? tradeIdTo = null, long? requestId = null);
  }
}