using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tar.Bitvavo.Api.Enums;
using tar.Bitvavo.Api.RestApi.Requests;
using tar.Bitvavo.Api.RestApi.Responses;

namespace tar.Bitvavo.Api.RestApi {
  internal class RestApiAccountActions : IRestApiAccountActions {
    private readonly BvRestClient _restApi;

    public RestApiAccountActions(BvRestClient restApi) {
      _restApi = restApi;
    }

    public Response<AccountCancelOrderResponse> CancelOrder(
      string market,
      Guid orderId = default,
      string clientOrderId = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Delete,
        apiPath: RestApiPath.Order,
        clientOrderId: clientOrderId,
        market: market,
        orderId: orderId
      );

      return _restApi.SendRequest<AccountCancelOrderResponse>(requestOptions);
    }

    public async Task<Response<AccountCancelOrderResponse>> CancelOrderAsync(
      string market,
      Guid orderId = default,
      string clientOrderId = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Delete,
        apiPath: RestApiPath.Order,
        clientOrderId: clientOrderId,
        market: market,
        orderId: orderId
      );

      return await _restApi.SendRequestAsync<AccountCancelOrderResponse>(requestOptions);
    }

    public Response<List<AccountCancelOrderResponse>> CancelOrders(string market) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Delete,
        apiPath: RestApiPath.Order,
        market: market
      );

      return _restApi.SendRequest<List<AccountCancelOrderResponse>>(requestOptions);
    }

    public async Task<Response<List<AccountCancelOrderResponse>>> CancelOrdersAsync(string market) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Delete,
        apiPath: RestApiPath.Order,
        market: market
      );

      return await _restApi.SendRequestAsync<List<AccountCancelOrderResponse>>(requestOptions);
    }

    public Response<AccountOrderResponse> PlaceLimitOrder(
      string market,
      TransactionSide side,
      AccountPlaceOrderLimitOptions limitOptions
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Post,
        apiPath: RestApiPath.Order,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          limitOptions: limitOptions
        ),
        orderType: AccountOrderType.Limit,
        side: side
      );

      return _restApi.SendRequest<AccountOrderResponse>(requestOptions);
    }

    public async Task<Response<AccountOrderResponse>> PlaceLimitOrderAsync(
      string market,
      TransactionSide side,
      AccountPlaceOrderLimitOptions limitOptions
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Post,
        apiPath: RestApiPath.Order,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          limitOptions: limitOptions
        ),
        orderType: AccountOrderType.Limit,
        side: side
      );

      return await _restApi.SendRequestAsync<AccountOrderResponse>(requestOptions);
    }

    public Response<AccountOrderResponse> PlaceMarketOrder(
      string market,
      TransactionSide side,
      AccountPlaceOrderMarketOptions marketOptions
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Post,
        apiPath: RestApiPath.Order,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          marketOptions: marketOptions
        ),
        orderType: AccountOrderType.Market,
        side: side
      );

      return _restApi.SendRequest<AccountOrderResponse>(requestOptions);
    }

    public async Task<Response<AccountOrderResponse>> PlaceMarketOrderAsync(
      string market,
      TransactionSide side,
      AccountPlaceOrderMarketOptions marketOptions
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Post,
        apiPath: RestApiPath.Order,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          marketOptions: marketOptions
        ),
        orderType: AccountOrderType.Market,
        side: side
      );

      return await _restApi.SendRequestAsync<AccountOrderResponse>(requestOptions);
    }

    public Response<AccountOrderResponse> PlaceStopLossLimitOrder(
      string market,
      TransactionSide side,
      AccountPlaceOrderLimitOptions limitOptions,
      AccountOrderTriggerOptions triggerOptions
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Post,
        apiPath: RestApiPath.Order,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          limitOptions: limitOptions,
          triggerOptions: triggerOptions
        ),
        orderType: AccountOrderType.StopLossLimit,
        side: side
      );

      return _restApi.SendRequest<AccountOrderResponse>(requestOptions);
    }

    public async Task<Response<AccountOrderResponse>> PlaceStopLossLimitOrderAsync(
      string market,
      TransactionSide side,
      AccountPlaceOrderLimitOptions limitOptions,
      AccountOrderTriggerOptions triggerOptions
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Post,
        apiPath: RestApiPath.Order,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          limitOptions: limitOptions,
          triggerOptions: triggerOptions
        ),
        orderType: AccountOrderType.StopLossLimit,
        side: side
      );

      return await _restApi.SendRequestAsync<AccountOrderResponse>(requestOptions);
    }

    public Response<AccountOrderResponse> PlaceStopLossOrder(
      string market,
      TransactionSide side,
      AccountPlaceOrderMarketOptions marketOptions,
      AccountOrderTriggerOptions triggerOptions
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Post,
        apiPath: RestApiPath.Order,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          marketOptions: marketOptions,
          triggerOptions: triggerOptions
        ),
        orderType: AccountOrderType.StopLoss,
        side: side
      );

      return _restApi.SendRequest<AccountOrderResponse>(requestOptions);
    }

    public async Task<Response<AccountOrderResponse>> PlaceStopLossOrderAsync(
      string market,
      TransactionSide side,
      AccountPlaceOrderMarketOptions marketOptions,
      AccountOrderTriggerOptions triggerOptions
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Post,
        apiPath: RestApiPath.Order,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          marketOptions: marketOptions,
          triggerOptions: triggerOptions
        ),
        orderType: AccountOrderType.StopLoss,
        side: side
      );

      return await _restApi.SendRequestAsync<AccountOrderResponse>(requestOptions);
    }

    public Response<AccountOrderResponse> PlaceTakeProfitLimitOrder(
      string market,
      TransactionSide side,
      AccountPlaceOrderLimitOptions limitOptions,
      AccountOrderTriggerOptions triggerOptions
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Post,
        apiPath: RestApiPath.Order,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          limitOptions: limitOptions,
          triggerOptions: triggerOptions
        ),
        orderType: AccountOrderType.TakeProfitLimit,
        side: side
      );

      return _restApi.SendRequest<AccountOrderResponse>(requestOptions);
    }

    public async Task<Response<AccountOrderResponse>> PlaceTakeProfitLimitOrderAsync(
      string market,
      TransactionSide side,
      AccountPlaceOrderLimitOptions limitOptions,
      AccountOrderTriggerOptions triggerOptions
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Post,
        apiPath: RestApiPath.Order,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          limitOptions: limitOptions,
          triggerOptions: triggerOptions
        ),
        orderType: AccountOrderType.TakeProfitLimit,
        side: side
      );

      return await _restApi.SendRequestAsync<AccountOrderResponse>(requestOptions);
    }

    public Response<AccountOrderResponse> PlaceTakeProfitOrder(
      string market,
      TransactionSide side,
      AccountPlaceOrderMarketOptions marketOptions,
      AccountOrderTriggerOptions triggerOptions
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Post,
        apiPath: RestApiPath.Order,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          marketOptions: marketOptions,
          triggerOptions: triggerOptions
        ),
        orderType: AccountOrderType.TakeProfit,
        side: side
      );

      return _restApi.SendRequest<AccountOrderResponse>(requestOptions);
    }

    public async Task<Response<AccountOrderResponse>> PlaceTakeProfitOrderAsync(
      string market,
      TransactionSide side,
      AccountPlaceOrderMarketOptions marketOptions,
      AccountOrderTriggerOptions triggerOptions
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Post,
        apiPath: RestApiPath.Order,
        market: market,
        placeOrderOptions: new AccountPlaceOrderOptions(
          marketOptions: marketOptions,
          triggerOptions: triggerOptions
        ),
        orderType: AccountOrderType.TakeProfit,
        side: side
      );

      return await _restApi.SendRequestAsync<AccountOrderResponse>(requestOptions);
    }

    public Response<AccountOrderResponse> UpdateLimitOrder(
      string market,
      AccountUpdateOrderLimitOptions limitOptions,
      Guid orderId = default,
      string clientOrderId = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Put,
        apiPath: RestApiPath.Order,
        clientOrderId: clientOrderId,
        market: market,
        orderId: orderId,
        updateOrderOptions: new AccountUpdateOrderOptions(
          limitOptions: limitOptions
        )
      );

      return _restApi.SendRequest<AccountOrderResponse>(requestOptions);
    }

    public async Task<Response<AccountOrderResponse>> UpdateLimitOrderAsync(
      string market,
      AccountUpdateOrderLimitOptions limitOptions,
      Guid orderId = default,
      string clientOrderId = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Put,
        apiPath: RestApiPath.Order,
        clientOrderId: clientOrderId,
        market: market,
        orderId: orderId,
        updateOrderOptions: new AccountUpdateOrderOptions(
          limitOptions: limitOptions
        )
      );

      return await _restApi.SendRequestAsync<AccountOrderResponse>(requestOptions);
    }

    public Response<AccountOrderResponse> UpdateStopLossTakeProfitLimitOrder(
      string market,
      AccountUpdateOrderLimitOptions limitOptions,
      AccountOrderTriggerOptions triggerOptions,
      Guid orderId = default,
      string clientOrderId = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Put,
        apiPath: RestApiPath.Order,
        clientOrderId: clientOrderId,
        market: market,
        orderId: orderId,
        updateOrderOptions: new AccountUpdateOrderOptions(
          limitOptions: limitOptions,
          triggerOptions: triggerOptions
        )
      );

      return _restApi.SendRequest<AccountOrderResponse>(requestOptions);
    }

    public async Task<Response<AccountOrderResponse>> UpdateStopLossTakeProfitLimitOrderAsync(
      string market,
      AccountUpdateOrderLimitOptions limitOptions,
      AccountOrderTriggerOptions triggerOptions,
      Guid orderId = default,
      string clientOrderId = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Put,
        apiPath: RestApiPath.Order,
        clientOrderId: clientOrderId,
        market: market,
        orderId: orderId,
        updateOrderOptions: new AccountUpdateOrderOptions(
          limitOptions: limitOptions,
          triggerOptions: triggerOptions
        )
      );

      return await _restApi.SendRequestAsync<AccountOrderResponse>(requestOptions);
    }

    public Response<AccountOrderResponse> UpdateStopLossTakeProfitOrder(
      string market,
      AccountUpdateOrderMarketOptions marketOptions,
      AccountOrderTriggerOptions triggerOptions,
      Guid orderId = default,
      string clientOrderId = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Put,
        apiPath: RestApiPath.Order,
        clientOrderId: clientOrderId,
        market: market,
        orderId: orderId,
        updateOrderOptions: new AccountUpdateOrderOptions(
          marketOptions: marketOptions,
          triggerOptions: triggerOptions
        )
      );

      return _restApi.SendRequest<AccountOrderResponse>(requestOptions);
    }

    public async Task<Response<AccountOrderResponse>> UpdateStopLossTakeProfitOrderAsync(
      string market,
      AccountUpdateOrderMarketOptions marketOptions,
      AccountOrderTriggerOptions triggerOptions,
      Guid orderId = default,
      string clientOrderId = null
    ) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Put,
        apiPath: RestApiPath.Order,
        clientOrderId: clientOrderId,
        market: market,
        orderId: orderId,
        updateOrderOptions: new AccountUpdateOrderOptions(
          marketOptions: marketOptions,
          triggerOptions: triggerOptions
        )
      );

      return await _restApi.SendRequestAsync<AccountOrderResponse>(requestOptions);
    }

    public Response<AccountWithdrawAssetResponse> WithdrawAsset(AccountWithdrawal withdrawal) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Post,
        apiPath: RestApiPath.Withdrawal,
        withdrawal: withdrawal
      );

      return _restApi.SendRequest<AccountWithdrawAssetResponse>(requestOptions);
    }

    public async Task<Response<AccountWithdrawAssetResponse>> WithdrawAssetAsync(AccountWithdrawal withdrawal) {
      RestRequestOptions requestOptions = new RestRequestOptions(
        addSignature: true,
        apiMethod: Method.Post,
        apiPath: RestApiPath.Withdrawal,
        withdrawal: withdrawal
      );

      return await _restApi.SendRequestAsync<AccountWithdrawAssetResponse>(requestOptions);
    }
  }
}