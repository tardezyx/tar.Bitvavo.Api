namespace tar.Bitvavo.Api.RestApi.Requests {
  public class AccountPlaceOrderOptions {
    public AccountPlaceOrderOptions(
      AccountPlaceOrderLimitOptions limitOptions,
      AccountOrderTriggerOptions triggerOptions = null
    ) {
      LimitOptions = limitOptions;
      TriggerOptions = triggerOptions;
    }

    public AccountPlaceOrderOptions(
      AccountPlaceOrderMarketOptions marketOptions,
      AccountOrderTriggerOptions triggerOptions = null
    ) {
      MarketOptions = marketOptions;
      TriggerOptions = triggerOptions;
    }

    public AccountPlaceOrderLimitOptions LimitOptions { get; }
    public AccountPlaceOrderMarketOptions MarketOptions { get; }
    public AccountOrderTriggerOptions TriggerOptions { get; }
  }
}