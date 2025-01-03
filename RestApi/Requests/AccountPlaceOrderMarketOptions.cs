﻿using System;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.RestApi.Requests {
  public class AccountPlaceOrderMarketOptions {
    public decimal? Amount { get; }
    public decimal? AmountQuote { get; }
    public Guid? ClientOrderId { get; }
    public bool DisableMarketProtection { get; }
    public bool ResponseRequired { get; }
    public AccountOrderSelfTradePrevention SelfTradePrevention { get; }
    public AccountOrderTimeInForce TimeInForce { get; }

    public AccountPlaceOrderMarketOptions(
      decimal? amount = null,
      bool amountIsAmountQuote = false,
      Guid? clientOrderId = null,
      bool disableMarketProtection = false,
      bool responseRequired = true,
      AccountOrderSelfTradePrevention selfTradePrevention = AccountOrderSelfTradePrevention.DecrementAndCancel,
      AccountOrderTimeInForce timeInForce = AccountOrderTimeInForce.GoodTilCanceled
    ) {
      Amount = amountIsAmountQuote ? null : amount;
      AmountQuote = amountIsAmountQuote ? amount : null;
      ClientOrderId = clientOrderId;
      DisableMarketProtection = disableMarketProtection;
      ResponseRequired = responseRequired;
      SelfTradePrevention = selfTradePrevention;
      TimeInForce = timeInForce;
    }
  }
}