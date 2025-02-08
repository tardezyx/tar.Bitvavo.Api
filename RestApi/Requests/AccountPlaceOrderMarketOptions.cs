using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.RestApi.Requests {
  public class AccountPlaceOrderMarketOptions {
    public decimal? Amount { get; }
    public decimal? AmountQuote { get; }
    public string ClientOrderId { get; }
    public bool DisableMarketProtection { get; }
    public bool ResponseRequired { get; }
    public AccountOrderSelfTradePrevention SelfTradePrevention { get; }

    public AccountPlaceOrderMarketOptions(
      decimal? amount = null,
      bool amountIsAmountQuote = false,
      string clientOrderId = null,
      bool disableMarketProtection = false,
      bool responseRequired = true,
      AccountOrderSelfTradePrevention selfTradePrevention = AccountOrderSelfTradePrevention.DecrementAndCancel
    ) {
      Amount = amountIsAmountQuote ? null : amount;
      AmountQuote = amountIsAmountQuote ? amount : null;
      ClientOrderId = clientOrderId;
      DisableMarketProtection = disableMarketProtection;
      ResponseRequired = responseRequired;
      SelfTradePrevention = selfTradePrevention;
    }
  }
}