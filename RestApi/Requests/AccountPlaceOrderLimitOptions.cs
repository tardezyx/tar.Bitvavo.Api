using System;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.RestApi.Requests {
  public class AccountPlaceOrderLimitOptions {
    public decimal? Amount { get; }
    public Guid? ClientOrderId { get; }
    public bool PostOnly { get; }
    public decimal Price { get; }
    public bool ResponseRequired { get; }
    public AccountOrderSelfTradePrevention SelfTradePrevention { get; }
    public AccountOrderTimeInForce TimeInForce { get; }

    public AccountPlaceOrderLimitOptions(
      decimal price,
      decimal? amount = null,
      Guid? clientOrderId = null,
      bool postOnly = false,
      bool responseRequired = true,
      AccountOrderSelfTradePrevention selfTradePrevention = AccountOrderSelfTradePrevention.DecrementAndCancel,
      AccountOrderTimeInForce timeInForce = AccountOrderTimeInForce.GoodTilCanceled
    ) {
      Amount = amount;
      ClientOrderId = clientOrderId;
      PostOnly = postOnly;
      Price = price;
      ResponseRequired = responseRequired;
      SelfTradePrevention = selfTradePrevention;
      TimeInForce = timeInForce;
    }
  }
}