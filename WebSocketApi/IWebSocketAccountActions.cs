﻿using System;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;
using tar.Bitvavo.Api.RestApi.Requests;

namespace tar.Bitvavo.Api.WebSocketApi {
  public interface IWebSocketAccountActions {
    Task CancelOrderAsync(string market, Guid orderId, bool orderIdIsClientOrderId = false, long? requestId = null);
    Task CancelOrdersAsync(string market, long? requestId = null);
    Task PlaceLimitOrderAsync(string market, TransactionSide side, AccountPlaceOrderLimitOptions limitOptions, long? requestId = null);
    Task PlaceMarketOrderAsync(string market, TransactionSide side, AccountPlaceOrderMarketOptions marketOptions, long? requestId = null);
    Task PlaceStopLossLimitOrderAsync(string market, TransactionSide side, AccountPlaceOrderLimitOptions limitOptions, AccountOrderTriggerOptions triggerOptions, long? requestId = null);
    Task PlaceStopLossOrderAsync(string market, TransactionSide side, AccountPlaceOrderMarketOptions marketOptions, AccountOrderTriggerOptions triggerOptions, long? requestId = null);
    Task PlaceTakeProfitLimitOrderAsync(string market, TransactionSide side, AccountPlaceOrderLimitOptions limitOptions, AccountOrderTriggerOptions triggerOptions, long? requestId = null);
    Task PlaceTakeProfitOrderAsync(string market, TransactionSide side, AccountPlaceOrderMarketOptions marketOptions, AccountOrderTriggerOptions triggerOptions, long? requestId = null);
    Task UpdateLimitOrderAsync(string market, Guid orderId, AccountUpdateOrderLimitOptions limitOptions, bool orderIdIsClientOrderId = false, long? requestId = null);
    Task UpdateStopLossTakeProfitLimitOrderAsync(string market, Guid orderId, AccountUpdateOrderLimitOptions limitOptions, AccountOrderTriggerOptions triggerOptions, bool orderIdIsClientOrderId = false, long? requestId = null);
    Task UpdateStopLossTakeProfitOrderAsync(string market, Guid orderId, AccountUpdateOrderMarketOptions marketOptions, AccountOrderTriggerOptions triggerOptions, bool orderIdIsClientOrderId = false, long? requestId = null);
    Task WithdrawAssetAsync(AccountWithdrawal withdrawal, long? requestId = null);
  }
}