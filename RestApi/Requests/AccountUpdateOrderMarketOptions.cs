using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.RestApi.Requests {
  public class AccountUpdateOrderMarketOptions {
    public decimal? Amount { get; }
    public decimal? AmountQuote { get; }
    public decimal? AmountRemaining { get; }
    public bool? DisableMarketProtection { get; }
    public bool ResponseRequired { get; }
    public AccountOrderSelfTradePrevention? SelfTradePrevention { get; }
    public AccountOrderTimeInForce? TimeInForce { get; }

    public AccountUpdateOrderMarketOptions(
      decimal? amount = null,
      decimal? amountQuote = null,
      decimal? amountRemaining = null,
      bool? disableMarketProtection = null,
      bool responseRequired = true,
      AccountOrderSelfTradePrevention? selfTradePrevention = null,
      AccountOrderTimeInForce? timeInForce = null
    ) {
      Amount = amount;
      AmountQuote = amountQuote;
      AmountRemaining = amountRemaining;
      DisableMarketProtection = disableMarketProtection;
      ResponseRequired = responseRequired;
      SelfTradePrevention = selfTradePrevention;
      TimeInForce = timeInForce;
    }
  }
}