using System;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;
using tar.Bitvavo.Api.WebSocketApi.Sends;

namespace tar.Bitvavo.Api.WebSocketApi {
  internal class WebSocketAccountInfos : IWebSocketAccountInfos {
    private readonly BvWebSocketClient _webSocket;

    public WebSocketAccountInfos(BvWebSocketClient webSocket) {
      _webSocket = webSocket;
    }

    public async Task GetAccountAsync(long? requestId = null) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetAccount,
        authRequired: true,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetBalanceAsync(string symbol = null, long? requestId = null) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetAccountBalance,
        authRequired: true,
        requestId: requestId,
        symbol: symbol
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetDepositAddressAsync(string symbol, long? requestId = null) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetAccountDepositAddress,
        authRequired: true,
        requestId: requestId,
        symbol: symbol
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetDepositHistoryAsync(
      string symbol = null,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetAccountDepositHistory,
        authRequired: true,
        end: end,
        limit: limit,
        requestId: requestId,
        start: start,
        symbol: symbol
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetFeesAsync(
      string market = null,
      FeeQuote? quote = null,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetAccountFees,
        authRequired: true,
        quote: quote,
        market: market,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetOpenOrdersAsync(
      string market = null,
      string @base = null,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetAccountOpenOrders,
        authRequired: true,
        @base: @base,
        market: market,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetOrderAsync(
      string market,
      Guid orderId,
      bool orderIdIsClientOrderId = false,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetAccountOrder,
        authRequired: true,
        market: market,
        orderId: orderId,
        orderIdIsClientOrderId: orderIdIsClientOrderId,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetOrdersAsync(
      string market,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null,
      Guid? orderIdFrom = null,
      Guid? orderIdTo = null,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetAccountOrders,
        authRequired: true,
        end: end,
        limit: limit,
        market: market,
        orderIdFrom: orderIdFrom,
        orderIdTo: orderIdTo,
        requestId: requestId,
        start: start
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
        action: WebSocketAction.GetAccountTrades,
        authRequired: true,
        end: end,
        limit: limit,
        market: market,
        requestId: requestId,
        start: start,
        tradeIdFrom: tradeIdFrom,
        tradeIdTo: tradeIdTo
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetTransactionHistoryAsync(
      AccountTransactionType? type = null,
      int? maxItems = null,
      int? page = null,
      DateTime? fromDate = null,
      DateTime? toDate = null,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetAccountTransactionHistory,
        authRequired: true,
        fromDate: fromDate,
        maxItems: maxItems,
        page: page,
        requestId: requestId,
        toDate: toDate,
        transactionType: type
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task GetWithdrawalHistoryAsync(
      string symbol = null,
      int? limit = null,
      DateTime? start = null,
      DateTime? end = null,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.GetAccountWithdrawalHistory,
        authRequired: true,
        end: end,
        limit: limit,
        requestId: requestId,
        start: start,
        symbol: symbol
      );

      await _webSocket.SendAsync(sendOptions);
    }
  }
}