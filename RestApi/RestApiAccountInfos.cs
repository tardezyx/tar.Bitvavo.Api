using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;
using tar.Bitvavo.Api.RestApi.Requests;
using tar.Bitvavo.Api.RestApi.Responses;

namespace tar.Bitvavo.Api.RestApi {
  internal class RestApiAccountInfos : IRestApiAccountInfos {
    private readonly BvRestClient _restApi;

    public RestApiAccountInfos(BvRestClient restApi) {
      _restApi = restApi;
    }

    public Response<AccountResponse> GetAccount() {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.Account
      );

      return _restApi.SendRequest<AccountResponse>(requestOptions);
    }

    public async Task<Response<AccountResponse>> GetAccountAsync() {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.Account
      );

      return await _restApi.SendRequestAsync<AccountResponse>(requestOptions);
    }

    public Response<List<AccountBalanceResponse>> GetBalance(string symbol = null) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.Balance,
        symbol: symbol
      );

      return _restApi.SendRequest<List<AccountBalanceResponse>>(requestOptions);
    }

    public async Task<Response<List<AccountBalanceResponse>>> GetBalanceAsync(string symbol = null) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.Balance,
        symbol: symbol
      );

      return await _restApi.SendRequestAsync<List<AccountBalanceResponse>>(requestOptions);
    }

    public Response<AccountDepositAddressResponse> GetDepositAddress(string symbol) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.Deposit,
        symbol: symbol
      );

      return _restApi.SendRequest<AccountDepositAddressResponse>(requestOptions);
    }

    public async Task<Response<AccountDepositAddressResponse>> GetDepositAddressAsync(string symbol) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.Deposit,
        symbol: symbol
      );

      return await _restApi.SendRequestAsync<AccountDepositAddressResponse>(requestOptions);
    }

    public Response<List<AccountDepositHistoryResponse>> GetDepositHistory(
      string symbol = null,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.DepositHistory,
        end: end,
        limit: limit,
        start: start,
        symbol: symbol
      );

      return _restApi.SendRequest<List<AccountDepositHistoryResponse>>(requestOptions);
    }

    public async Task<Response<List<AccountDepositHistoryResponse>>> GetDepositHistoryAsync(
      string symbol = null,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.DepositHistory,
        end: end,
        limit: limit,
        start: start,
        symbol: symbol
      );

      return await _restApi.SendRequestAsync<List<AccountDepositHistoryResponse>>(requestOptions);
    }

    public Response<AccountFeesResponse> GetFees(
      string market = null,
      FeeQuote? quote = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.AccountFees,
        market: market,
        quote: quote
      );

      return _restApi.SendRequest<AccountFeesResponse>(requestOptions);
    }

    public async Task<Response<AccountFeesResponse>> GetFeesAsync(
      string market = null,
      FeeQuote? quote = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.AccountFees,
        market: market,
        quote: quote
      );

      return await _restApi.SendRequestAsync<AccountFeesResponse>(requestOptions);
    }

    public Response<List<AccountOrderResponse>> GetOpenOrders(
      string market = null,
      string @base = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.OpenOrders,
        @base: @base,
        market: market
      );

      return _restApi.SendRequest<List<AccountOrderResponse>>(requestOptions);
    }

    public async Task<Response<List<AccountOrderResponse>>> GetOpenOrdersAsync(
      string market = null,
      string @base = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.OpenOrders,
        @base: @base,
        market: market
      );

      return await _restApi.SendRequestAsync<List<AccountOrderResponse>>(requestOptions);
    }

    public Response<AccountOrderResponse> GetOrder(
      string market,
      Guid orderId = default,
      string clientOrderId = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.Order,
        clientOrderId: clientOrderId,
        market: market,
        orderId: orderId
      );

      return _restApi.SendRequest<AccountOrderResponse>(requestOptions);
    }

    public async Task<Response<AccountOrderResponse>> GetOrderAsync(
      string market,
      Guid orderId = default,
      string clientOrderId = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.Order,
        clientOrderId: clientOrderId,
        market: market,
        orderId: orderId
      );

      return await _restApi.SendRequestAsync<AccountOrderResponse>(requestOptions);
    }

    public Response<List<AccountOrderResponse>> GetOrders(
      string market,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null,
      Guid? orderIdFrom = null,
      Guid? orderIdTo = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.Orders,
        end: end,
        limit: limit,
        market: market,
        orderIdFrom: orderIdFrom,
        orderIdTo: orderIdTo,
        start: start
      );

      return _restApi.SendRequest<List<AccountOrderResponse>>(requestOptions);
    }

    public async Task<Response<List<AccountOrderResponse>>> GetOrdersAsync(
      string market,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null,
      Guid? orderIdFrom = null,
      Guid? orderIdTo = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.Orders,
        end: end,
        limit: limit,
        market: market,
        orderIdFrom: orderIdFrom,
        orderIdTo: orderIdTo,
        start: start
      );

      return await _restApi.SendRequestAsync<List<AccountOrderResponse>>(requestOptions);
    }

    public Response<List<AccountTradeResponse>> GetTrades(
      string market,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null,
      Guid? tradeIdFrom = null,
      Guid? tradeIdTo = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.Trades,
        end: end,
        limit: limit,
        market: market,
        start: start,
        tradeIdFrom: tradeIdFrom,
        tradeIdTo: tradeIdTo
      );

      return _restApi.SendRequest<List<AccountTradeResponse>>(requestOptions);
    }

    public async Task<Response<List<AccountTradeResponse>>> GetTradesAsync(
      string market,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null,
      Guid? tradeIdFrom = null,
      Guid? tradeIdTo = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.Trades,
        end: end,
        limit: limit,
        market: market,
        start: start,
        tradeIdFrom: tradeIdFrom,
        tradeIdTo: tradeIdTo
      );

      return await _restApi.SendRequestAsync<List<AccountTradeResponse>>(requestOptions);
    }

    public Response<AccountTransactionHistoryResponse> GetTransactionHistory(
      AccountTransactionType? type = null,
      int? maxItems = null,
      int? page = null,
      DateTime? fromDate = null,
      DateTime? toDate = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.AccountHistory,
        fromDate: fromDate,
        maxItems: maxItems,
        page: page,
        toDate: toDate,
        transactionType: type
      );

      return _restApi.SendRequest<AccountTransactionHistoryResponse>(requestOptions);
    }

    public async Task<Response<AccountTransactionHistoryResponse>> GetTransactionHistoryAsync(
      AccountTransactionType? type = null,
      int? maxItems = null,
      int? page = null,
      DateTime? fromDate = null,
      DateTime? toDate = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.AccountHistory,
        fromDate: fromDate,
        maxItems: maxItems,
        page: page,
        toDate: toDate,
        transactionType: type
      );

      return await _restApi.SendRequestAsync<AccountTransactionHistoryResponse>(requestOptions);
    }

    public Response<List<AccountWithdrawalHistoryResponse>> GetWithdrawalHistory(
      string symbol = null,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.WithdrawalHistory,
        end: end,
        limit: limit,
        start: start,
        symbol: symbol
      );

      return _restApi.SendRequest<List<AccountWithdrawalHistoryResponse>>(requestOptions);
    }

    public async Task<Response<List<AccountWithdrawalHistoryResponse>>> GetWithdrawalHistoryAsync(
      string symbol = null,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Get,
        apiPath: RestApiPath.WithdrawalHistory,
        end: end,
        limit: limit,
        start: start,
        symbol: symbol
      );

      return await _restApi.SendRequestAsync<List<AccountWithdrawalHistoryResponse>>(requestOptions);
    }
  }
}