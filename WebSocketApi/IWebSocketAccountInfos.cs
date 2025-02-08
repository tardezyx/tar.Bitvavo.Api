using System;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.WebSocketApi {
  public interface IWebSocketAccountInfos {
    Task GetAccountAsync(long? requestId = null);
    Task GetBalanceAsync(string symbol = null, long? requestId = null);
    Task GetDepositAddressAsync(string symbol, long? requestId = null);
    Task GetDepositHistoryAsync(string symbol = null, int? limit = null, DateTime? start = null, DateTime? end = null, long? requestId = null);
    Task GetFeesAsync(string market = null, FeeQuote? quote = null, long? requestId = null);
    Task GetOpenOrdersAsync(string market = null, string @base = null, long? requestId = null);
    Task GetOrderAsync(string market, Guid orderId = default, string clientOrderId = null, long? requestId = null);
    Task GetOrdersAsync(string market, int? limit = null, DateTime? start = null, DateTime? end = null, Guid? orderIdFrom = null, Guid? orderIdTo = null, long? requestId = null);
    Task GetTradesAsync(string market, int? limit = null, DateTime? start = null, DateTime? end = null, Guid? tradeIdFrom = null, Guid? tradeIdTo = null, long? requestId = null);
    Task GetTransactionHistoryAsync(AccountTransactionType? type = null, int? maxItems = null, int? page = null, DateTime? fromDate = null, DateTime? toDate = null, long? requestId = null);
    Task GetWithdrawalHistoryAsync(string symbol = null, int? limit = null, DateTime? start = null, DateTime? end = null, long? requestId = null);
  }
}