using System;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;
using tar.Bitvavo.Api.RestApi.Requests;
using tar.Bitvavo.Api.WebSocketApi.Sends;

namespace tar.Bitvavo.Api.WebSocketApi {
  internal class WebSocketAccountActions : IWebSocketAccountActions {
    private readonly BvWebSocketClient _webSocket;

    public WebSocketAccountActions(BvWebSocketClient webSocket) {
      _webSocket = webSocket;
    }

    public async Task CancelOrderAsync(
      string market,
      Guid orderId = default,
      string clientOrderId = null,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.AccountCancelOrder,
        authRequired: true,
        clientOrderId: clientOrderId,
        market: market,
        orderId: orderId,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task CancelOrdersAsync(
      string market,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.AccountCancelOrders,
        authRequired: true,
        market: market,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task PlaceLimitOrderAsync(
      string market,
      TransactionSide side,
      AccountPlaceOrderLimitOptions limitOptions,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.AccountPlaceOrder,
        authRequired: true,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          limitOptions: limitOptions
        ),
        orderType: AccountOrderType.Limit,
        side: side,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task PlaceMarketOrderAsync(
      string market,
      TransactionSide side,
      AccountPlaceOrderMarketOptions marketOptions,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.AccountPlaceOrder,
        authRequired: true,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          marketOptions: marketOptions
        ),
        orderType: AccountOrderType.Market,
        side: side,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task PlaceStopLossLimitOrderAsync(
      string market,
      TransactionSide side,
      AccountPlaceOrderLimitOptions limitOptions,
      AccountOrderTriggerOptions triggerOptions,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.AccountPlaceOrder,
        authRequired: true,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          limitOptions: limitOptions,
          triggerOptions: triggerOptions
        ),
        orderType: AccountOrderType.StopLossLimit,
        side: side,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task PlaceStopLossOrderAsync(
      string market,
      TransactionSide side,
      AccountPlaceOrderMarketOptions marketOptions,
      AccountOrderTriggerOptions triggerOptions,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.AccountPlaceOrder,
        authRequired: true,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          marketOptions: marketOptions,
          triggerOptions: triggerOptions
        ),
        orderType: AccountOrderType.StopLoss,
        side: side,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task PlaceTakeProfitLimitOrderAsync(
      string market,
      TransactionSide side,
      AccountPlaceOrderLimitOptions limitOptions,
      AccountOrderTriggerOptions triggerOptions,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.AccountPlaceOrder,
        authRequired: true,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          limitOptions: limitOptions,
          triggerOptions: triggerOptions
        ),
        orderType: AccountOrderType.TakeProfitLimit,
        side: side,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task PlaceTakeProfitOrderAsync(
      string market,
      TransactionSide side,
      AccountPlaceOrderMarketOptions marketOptions,
      AccountOrderTriggerOptions triggerOptions,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.AccountPlaceOrder,
        authRequired: true,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          marketOptions: marketOptions,
          triggerOptions: triggerOptions
        ),
        orderType: AccountOrderType.TakeProfit,
        side: side,
        requestId: requestId
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task UpdateLimitOrderAsync(
      string market,
      AccountUpdateOrderLimitOptions limitOptions,
      Guid orderId = default,
      string clientOrderId = null,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.AccountUpdateOrder,
        authRequired: true,
        clientOrderId: clientOrderId,
        market: market,
        orderId: orderId,
        requestId: requestId,
        updateOrderOptions: new AccountUpdateOrderOptions(
          limitOptions: limitOptions
        )
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task UpdateStopLossTakeProfitLimitOrderAsync(
      string market,
      AccountUpdateOrderLimitOptions limitOptions,
      AccountOrderTriggerOptions triggerOptions,
      Guid orderId = default,
      string clientOrderId = null,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.AccountUpdateOrder,
        authRequired: true,
        clientOrderId: clientOrderId,
        market: market,
        orderId: orderId,
        requestId: requestId,
        updateOrderOptions: new AccountUpdateOrderOptions(
          limitOptions: limitOptions,
          triggerOptions: triggerOptions
        )
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task UpdateStopLossTakeProfitOrderAsync(
      string market,
      AccountUpdateOrderMarketOptions marketOptions,
      AccountOrderTriggerOptions triggerOptions,
      Guid orderId = default,
      string clientOrderId = null,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.AccountUpdateOrder,
        authRequired: true,
        clientOrderId: clientOrderId,
        market: market,
        orderId: orderId,
        requestId: requestId,
        updateOrderOptions: new AccountUpdateOrderOptions(
          marketOptions: marketOptions,
          triggerOptions: triggerOptions
        )
      );

      await _webSocket.SendAsync(sendOptions);
    }

    public async Task WithdrawAssetAsync(
      AccountWithdrawal withdrawal,
      long? requestId = null
    ) {
      SendOptions sendOptions = new SendOptions(
        action: WebSocketAction.AccountWithdrawAssets,
        authRequired: true,
        requestId: requestId,
        withdrawal: withdrawal
      );

      await _webSocket.SendAsync(sendOptions);
    }
  }
}