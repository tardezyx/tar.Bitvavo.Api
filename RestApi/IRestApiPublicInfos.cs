using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;
using tar.Bitvavo.Api.RestApi.Responses;

namespace tar.Bitvavo.Api.RestApi {
  public interface IRestApiPublicInfos {
    Response<MarketAssetResponse> GetAsset(string symbol);
    Task<Response<MarketAssetResponse>> GetAssetAsync(string symbol);
    Response<List<MarketAssetResponse>> GetAssets();
    Task<Response<List<MarketAssetResponse>>> GetAssetsAsync();
    Response<List<MarketCandlesResponse>> GetCandles(string market, MarketInterval interval = MarketInterval._4h, int? limit = null, DateTime? start = null, DateTime? end = null);
    Task<Response<List<MarketCandlesResponse>>> GetCandlesAsync(string market, MarketInterval interval = MarketInterval._4h, int? limit = null, DateTime? start = null, DateTime? end = null);
    Response<MarketResponse> GetMarket(string market);
    Task<Response<MarketResponse>> GetMarketAsync(string market);
    Response<List<MarketResponse>> GetMarkets();
    Task<Response<List<MarketResponse>>> GetMarketsAsync();
    Response<MarketOrderBookResponse> GetOrderBook(string market, int? depth = null);
    Task<Response<MarketOrderBookResponse>> GetOrderBookAsync(string market, int? depth = null);
    Response<ServerTimeResponse> GetServerTime();
    Task<Response<ServerTimeResponse>> GetServerTimeAsync();
    Response<MarketTicker24hResponse> GetTicker24h(string market);
    Task<Response<MarketTicker24hResponse>> GetTicker24hAsync(string market);
    Response<List<MarketTicker24hResponse>> GetTicker24hs();
    Task<Response<List<MarketTicker24hResponse>>> GetTicker24hsAsync();
    Response<MarketTickerBookResponse> GetTickerBook(string market);
    Task<Response<MarketTickerBookResponse>> GetTickerBookAsync(string market);
    Response<List<MarketTickerBookResponse>> GetTickerBooks();
    Task<Response<List<MarketTickerBookResponse>>> GetTickerBooksAsync();
    Response<MarketTickerPriceResponse> GetTickerPrice(string market);
    Task<Response<MarketTickerPriceResponse>> GetTickerPriceAsync(string market);
    Response<List<MarketTickerPriceResponse>> GetTickerPrices();
    Task<Response<List<MarketTickerPriceResponse>>> GetTickerPricesAsync();
    Response<List<MarketTradesResponse>> GetTrades(string market, int? limit = null, DateTime? start = null, DateTime? end = null, Guid? tradeIdFrom = null, Guid? tradeIdTo = null);
    Task<Response<List<MarketTradesResponse>>> GetTradesAsync(string market, int? limit = null, DateTime? start = null, DateTime? end = null, Guid? tradeIdFrom = null, Guid? tradeIdTo = null);
  }
}