using System.Collections.Generic;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.WebSocketApi {
  public interface IWebSocketSubscriptions {
    Task SubscribeToAccountOrdersAsync(List<string> markets, long? requestId = null);
    Task SubscribeToMarketCandlesAsync(List<string> markets, List<MarketInterval> intervals, long? requestId = null);
    Task SubscribeToMarketOrderBookAsync(List<string> markets, long? requestId = null);
    Task SubscribeToMarketTicker24hAsync(List<string> markets, long? requestId = null);
    Task SubscribeToMarketTickerAsync(List<string> markets, long? requestId = null);
    Task SubscribeToMarketTradesAsync(List<string> markets, long? requestId = null);
    Task UnsubscribeFromAccountOrdersAsync(List<string> markets, long? requestId = null);
    Task UnsubscribeFromMarketCandlesAsync(List<string> markets, List<MarketInterval> intervals, long? requestId = null);
    Task UnsubscribeFromMarketOrderBookAsync(List<string> markets, long? requestId = null);
    Task UnsubscribeFromMarketTicker24hAsync(List<string> markets, long? requestId = null);
    Task UnsubscribeFromMarketTickerAsync(List<string> markets, long? requestId = null);
    Task UnsubscribeFromMarketTradesAsync(List<string> markets, long? requestId = null);
  }
}