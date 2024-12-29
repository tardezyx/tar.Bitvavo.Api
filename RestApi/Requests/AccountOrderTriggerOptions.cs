using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.RestApi.Requests {
  public class AccountOrderTriggerOptions {
    public decimal TriggerAmount { get; }
    public AccountOrderTriggerReference TriggerReference { get; }
    public string TriggerType { get; } = "price";

    public AccountOrderTriggerOptions(
      decimal triggerAmount,
      AccountOrderTriggerReference triggerReference
    ) {
      TriggerAmount = triggerAmount;
      TriggerReference = triggerReference;
    }
  }
}