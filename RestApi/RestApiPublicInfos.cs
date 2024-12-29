using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;
using tar.Bitvavo.Api.RestApi.Requests;
using tar.Bitvavo.Api.RestApi.Responses;

namespace tar.Bitvavo.Api.RestApi {
  internal class RestApiPublicInfos : IRestApiPublicInfos {
    private readonly BvRestClient _restApi;

    public RestApiPublicInfos(BvRestClient restApi) {
      _restApi = restApi;
    }

    public Response<MarketAssetResponse> GetAsset(string symbol) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.Assets,
        symbol: symbol
      );

      return _restApi.SendRequest<MarketAssetResponse>(requestOptions);
    }

    public async Task<Response<MarketAssetResponse>> GetAssetAsync(string symbol) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.Assets,
        symbol: symbol
      );

      return await _restApi.SendRequestAsync<MarketAssetResponse>(requestOptions);
    }

    public Response<List<MarketAssetResponse>> GetAssets() {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.Assets
      );

      return _restApi.SendRequest<List<MarketAssetResponse>>(requestOptions);
    }

    public async Task<Response<List<MarketAssetResponse>>> GetAssetsAsync() {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.Assets
      );

      return await _restApi.SendRequestAsync<List<MarketAssetResponse>>(requestOptions);
    }

    public Response<List<MarketCandlesResponse>> GetCandles(
      string market,
      MarketInterval interval = MarketInterval._4h,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.MarketCandles,
        apiPathMarket: market,
        end: end,
        interval: interval,
        limit: limit,
        start: start
      );

      return _restApi.SendRequest<List<MarketCandlesResponse>>(requestOptions);
    }

    public async Task<Response<List<MarketCandlesResponse>>> GetCandlesAsync(
      string market,
      MarketInterval interval = MarketInterval._4h,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.MarketCandles,
        apiPathMarket: market,
        end: end,
        interval: interval,
        limit: limit,
        start: start
      );

      return await _restApi.SendRequestAsync<List<MarketCandlesResponse>>(requestOptions);
    }

    public Response<MarketResponse> GetMarket(string market) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.Markets,
        market: market
      );

      return _restApi.SendRequest<MarketResponse>(requestOptions);
    }

    public async Task<Response<MarketResponse>> GetMarketAsync(string market) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.Markets,
        market: market
      );

      return await _restApi.SendRequestAsync<MarketResponse>(requestOptions);
    }

    public Response<List<MarketResponse>> GetMarkets() {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.Markets
      );

      return _restApi.SendRequest<List<MarketResponse>>(requestOptions);
    }

    public async Task<Response<List<MarketResponse>>> GetMarketsAsync() {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.Markets
      );

      return await _restApi.SendRequestAsync<List<MarketResponse>>(requestOptions);
    }

    public Response<MarketOrderBookResponse> GetOrderBook(
      string market,
      int? depth = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.MarketBook,
        apiPathMarket: market,
        depth: depth
      );

      return _restApi.SendRequest<MarketOrderBookResponse>(requestOptions);
    }

    public async Task<Response<MarketOrderBookResponse>> GetOrderBookAsync(
      string market,
      int? depth = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.MarketBook,
        apiPathMarket: market,
        depth: depth
      );

      return await _restApi.SendRequestAsync<MarketOrderBookResponse>(requestOptions);
    }

    public Response<ServerTimeResponse> GetServerTime() {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.Time
      );

      return _restApi.SendRequest<ServerTimeResponse>(requestOptions);
    }

    public async Task<Response<ServerTimeResponse>> GetServerTimeAsync() {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.Time
      );

      return await _restApi.SendRequestAsync<ServerTimeResponse>(requestOptions);
    }

    public Response<MarketTicker24hResponse> GetTicker24h(string market) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.Ticker24h,
        market: market
      );

      return _restApi.SendRequest<MarketTicker24hResponse>(requestOptions);
    }

    public async Task<Response<MarketTicker24hResponse>> GetTicker24hAsync(string market) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.Ticker24h,
        market: market
      );

      return await _restApi.SendRequestAsync<MarketTicker24hResponse>(requestOptions);
    }

    public Response<List<MarketTicker24hResponse>> GetTicker24hs() {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.Ticker24h
      );

      return _restApi.SendRequest<List<MarketTicker24hResponse>>(requestOptions);
    }

    public async Task<Response<List<MarketTicker24hResponse>>> GetTicker24hsAsync() {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.Ticker24h
      );

      return await _restApi.SendRequestAsync<List<MarketTicker24hResponse>>(requestOptions);
    }

    public Response<MarketTickerBookResponse> GetTickerBook(string market) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.TickerBook,
        market: market
      );

      return _restApi.SendRequest<MarketTickerBookResponse>(requestOptions);
    }

    public async Task<Response<MarketTickerBookResponse>> GetTickerBookAsync(string market) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.TickerBook,
        market: market
      );

      return await _restApi.SendRequestAsync<MarketTickerBookResponse>(requestOptions);
    }

    public Response<List<MarketTickerBookResponse>> GetTickerBooks() {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.TickerBook
      );

      return _restApi.SendRequest<List<MarketTickerBookResponse>>(requestOptions);
    }

    public async Task<Response<List<MarketTickerBookResponse>>> GetTickerBooksAsync() {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.TickerBook
      );

      return await _restApi.SendRequestAsync<List<MarketTickerBookResponse>>(requestOptions);
    }

    public Response<MarketTickerPriceResponse> GetTickerPrice(string market) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.TickerPrice,
        market: market
      );

      return _restApi.SendRequest<MarketTickerPriceResponse>(requestOptions);
    }

    public async Task<Response<MarketTickerPriceResponse>> GetTickerPriceAsync(string market) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.TickerPrice,
        market: market
      );

      return await _restApi.SendRequestAsync<MarketTickerPriceResponse>(requestOptions);
    }

    public Response<List<MarketTickerPriceResponse>> GetTickerPrices() {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.TickerPrice
      );

      return _restApi.SendRequest<List<MarketTickerPriceResponse>>(requestOptions);
    }

    public async Task<Response<List<MarketTickerPriceResponse>>> GetTickerPricesAsync() {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.TickerPrice
      );

      return await _restApi.SendRequestAsync<List<MarketTickerPriceResponse>>(requestOptions);
    }

    public Response<List<MarketTradesResponse>> GetTrades(
      string market,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null,
      Guid? tradeIdFrom = null,
      Guid? tradeIdTo = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.MarketTrades,
        apiPathMarket: market,
        end: end,
        limit: limit,
        start: start,
        tradeIdFrom: tradeIdFrom,
        tradeIdTo: tradeIdTo
      );

      return _restApi.SendRequest<List<MarketTradesResponse>>(requestOptions);
    }

    public async Task<Response<List<MarketTradesResponse>>> GetTradesAsync(
      string market,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null,
      Guid? tradeIdFrom = null,
      Guid? tradeIdTo = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        apiMethod: Method.Get,
        apiPath: RestApiPath.MarketTrades,
        apiPathMarket: market,
        end: end,
        limit: limit,
        start: start,
        tradeIdFrom: tradeIdFrom,
        tradeIdTo: tradeIdTo
      );

      return await _restApi.SendRequestAsync<List<MarketTradesResponse>>(requestOptions);
    }
  }
}