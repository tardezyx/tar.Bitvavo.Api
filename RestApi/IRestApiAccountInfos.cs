using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;
using tar.Bitvavo.Api.RestApi.Responses;

namespace tar.Bitvavo.Api.RestApi {
  public interface IRestApiAccountInfos {
    Response<AccountResponse> GetAccount();
    Task<Response<AccountResponse>> GetAccountAsync();
    Response<List<AccountBalanceResponse>> GetBalance(string symbol = null);
    Task<Response<List<AccountBalanceResponse>>> GetBalanceAsync(string symbol = null);
    Response<AccountDepositAddressResponse> GetDepositAddress(string symbol);
    Task<Response<AccountDepositAddressResponse>> GetDepositAddressAsync(string symbol);
    Response<List<AccountDepositHistoryResponse>> GetDepositHistory(string symbol = null, int? limit = null, DateTime? start = null, DateTime? end = null);
    Task<Response<List<AccountDepositHistoryResponse>>> GetDepositHistoryAsync(string symbol = null, int? limit = null, DateTime? start = null, DateTime? end = null);
    Response<AccountFeesResponse> GetFees(string market = null, FeeQuote? quote = null);
    Task<Response<AccountFeesResponse>> GetFeesAsync(string market = null, FeeQuote? quote = null);
    Response<List<AccountOrderResponse>> GetOpenOrders(string market = null, string @base = null);
    Task<Response<List<AccountOrderResponse>>> GetOpenOrdersAsync(string market = null, string @base = null);
    Response<AccountOrderResponse> GetOrder(string market, Guid orderId = default, string clientOrderId = null);
    Task<Response<AccountOrderResponse>> GetOrderAsync(string market, Guid orderId = default, string clientOrderId = null);
    Response<List<AccountOrderResponse>> GetOrders(string market, int? limit = null, DateTime? start = null, DateTime? end = null, Guid? orderIdFrom = null, Guid? orderIdTo = null);
    Task<Response<List<AccountOrderResponse>>> GetOrdersAsync(string market, int? limit = null, DateTime? start = null, DateTime? end = null, Guid? orderIdFrom = null, Guid? orderIdTo = null);
    Response<List<AccountTradeResponse>> GetTrades(string market, int? limit = null, DateTime? start = null, DateTime? end = null, Guid? tradeIdFrom = null, Guid? tradeIdTo = null);
    Task<Response<List<AccountTradeResponse>>> GetTradesAsync(string market, int? limit = null, DateTime? start = null, DateTime? end = null, Guid? tradeIdFrom = null, Guid? tradeIdTo = null);
    Response<AccountTransactionHistoryResponse> GetTransactionHistory(AccountTransactionType? type = null, int? maxItems = null, int? page = null, DateTime? fromDate = null, DateTime? toDate = null);
    Task<Response<AccountTransactionHistoryResponse>> GetTransactionHistoryAsync(AccountTransactionType? type = null, int? maxItems = null, int? page = null, DateTime? fromDate = null, DateTime? toDate = null);
    Response<List<AccountWithdrawalHistoryResponse>> GetWithdrawalHistory(string symbol = null, int? limit = null, DateTime? start = null, DateTime? end = null);
    Task<Response<List<AccountWithdrawalHistoryResponse>>> GetWithdrawalHistoryAsync(string symbol = null, int? limit = null, DateTime? start = null, DateTime? end = null);
  }
}