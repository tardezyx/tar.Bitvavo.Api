using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;
using tar.Bitvavo.Api.RestApi.Requests;
using tar.Bitvavo.Api.RestApi.Responses;

namespace tar.Bitvavo.Api.RestApi {
  public interface IRestApiAccountActions {
    Response<AccountCancelOrderResponse> CancelOrder(string market, Guid orderId = default, string clientOrderId = null);
    Task<Response<AccountCancelOrderResponse>> CancelOrderAsync(string market, Guid orderId = default, string clientOrderId = null);
    Response<List<AccountCancelOrderResponse>> CancelOrders(string market);
    Task<Response<List<AccountCancelOrderResponse>>> CancelOrdersAsync(string market);
    Response<AccountOrderResponse> PlaceLimitOrder(string market, TransactionSide side, AccountPlaceOrderLimitOptions limitOptions);
    Task<Response<AccountOrderResponse>> PlaceLimitOrderAsync(string market, TransactionSide side, AccountPlaceOrderLimitOptions limitOptions);
    Response<AccountOrderResponse> PlaceMarketOrder(string market, TransactionSide side, AccountPlaceOrderMarketOptions marketOptions);
    Task<Response<AccountOrderResponse>> PlaceMarketOrderAsync(string market, TransactionSide side, AccountPlaceOrderMarketOptions marketOptions);
    Response<AccountOrderResponse> PlaceStopLossLimitOrder(string market, TransactionSide side, AccountPlaceOrderLimitOptions limitOptions, AccountOrderTriggerOptions triggerOptions);
    Task<Response<AccountOrderResponse>> PlaceStopLossLimitOrderAsync(string market, TransactionSide side, AccountPlaceOrderLimitOptions limitOptions, AccountOrderTriggerOptions triggerOptions);
    Response<AccountOrderResponse> PlaceStopLossOrder(string market, TransactionSide side, AccountPlaceOrderMarketOptions marketOptions, AccountOrderTriggerOptions triggerOptions);
    Task<Response<AccountOrderResponse>> PlaceStopLossOrderAsync(string market, TransactionSide side, AccountPlaceOrderMarketOptions marketOptions, AccountOrderTriggerOptions triggerOptions);
    Response<AccountOrderResponse> PlaceTakeProfitLimitOrder(string market, TransactionSide side, AccountPlaceOrderLimitOptions limitOptions, AccountOrderTriggerOptions triggerOptions);
    Task<Response<AccountOrderResponse>> PlaceTakeProfitLimitOrderAsync(string market, TransactionSide side, AccountPlaceOrderLimitOptions limitOptions, AccountOrderTriggerOptions triggerOptions);
    Response<AccountOrderResponse> PlaceTakeProfitOrder(string market, TransactionSide side, AccountPlaceOrderMarketOptions marketOptions, AccountOrderTriggerOptions triggerOptions);
    Task<Response<AccountOrderResponse>> PlaceTakeProfitOrderAsync(string market, TransactionSide side, AccountPlaceOrderMarketOptions marketOptions, AccountOrderTriggerOptions triggerOptions);
    Response<AccountOrderResponse> UpdateLimitOrder(string market, AccountUpdateOrderLimitOptions limitOptions, Guid orderId = default, string clientOrderId = null);
    Task<Response<AccountOrderResponse>> UpdateLimitOrderAsync(string market, AccountUpdateOrderLimitOptions limitOptions, Guid orderId = default, string clientOrderId = null);
    Response<AccountOrderResponse> UpdateStopLossTakeProfitLimitOrder(string market, AccountUpdateOrderLimitOptions limitOptions, AccountOrderTriggerOptions triggerOptions, Guid orderId = default, string clientOrderId = null);
    Task<Response<AccountOrderResponse>> UpdateStopLossTakeProfitLimitOrderAsync(string market, AccountUpdateOrderLimitOptions limitOptions, AccountOrderTriggerOptions triggerOptions, Guid orderId = default, string clientOrderId = null);
    Response<AccountOrderResponse> UpdateStopLossTakeProfitOrder(string market, AccountUpdateOrderMarketOptions marketOptions, AccountOrderTriggerOptions triggerOptions, Guid orderId = default, string clientOrderId = null);
    Task<Response<AccountOrderResponse>> UpdateStopLossTakeProfitOrderAsync(string market, AccountUpdateOrderMarketOptions marketOptions, AccountOrderTriggerOptions triggerOptions, Guid orderId = default, string clientOrderId = null);
    Response<AccountWithdrawAssetResponse> WithdrawAsset(AccountWithdrawal withdrawal);
    Task<Response<AccountWithdrawAssetResponse>> WithdrawAssetAsync(AccountWithdrawal withdrawal);
  }
}