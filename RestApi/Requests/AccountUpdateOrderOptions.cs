namespace tar.Bitvavo.Api.RestApi.Requests {
  public class AccountUpdateOrderOptions {
    public AccountUpdateOrderOptions(
      AccountUpdateOrderLimitOptions limitOptions,
      AccountOrderTriggerOptions triggerOptions = null
    ) {
      LimitOptions = limitOptions;
      TriggerOptions = triggerOptions;
    }

    public AccountUpdateOrderOptions(
      AccountUpdateOrderMarketOptions marketOptions,
      AccountOrderTriggerOptions triggerOptions = null
    ) {
      MarketOptions = marketOptions;
      TriggerOptions = triggerOptions;
    }

    public AccountUpdateOrderLimitOptions LimitOptions { get; }
    public AccountUpdateOrderMarketOptions MarketOptions { get; }
    public AccountOrderTriggerOptions TriggerOptions { get; }
  }
}