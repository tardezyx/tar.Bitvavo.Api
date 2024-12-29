using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.RestApi.Requests {
  public class AccountUpdateOrderLimitOptions {
    public decimal? Amount { get; }
    public decimal? AmountRemaining { get; }
    public bool? PostOnly { get; }
    public decimal? Price { get; }
    public bool ResponseRequired { get; }
    public AccountOrderSelfTradePrevention? SelfTradePrevention { get; }
    public AccountOrderTimeInForce? TimeInForce { get; }

    public AccountUpdateOrderLimitOptions(
      decimal? amount = null,
      decimal? amountRemaining = null,
      bool? postOnly = null,
      decimal? price = null,
      bool responseRequired = true,
      AccountOrderSelfTradePrevention? selfTradePrevention = null,
      AccountOrderTimeInForce? timeInForce = null
    ) {
      Amount = amount;
      AmountRemaining = amountRemaining;
      PostOnly = postOnly;
      Price = price;
      ResponseRequired = responseRequired;
      SelfTradePrevention = selfTradePrevention;
      TimeInForce = timeInForce;
    }
  }
}