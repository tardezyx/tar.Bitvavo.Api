using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<AccountCapability>))]
  public enum AccountCapability {
    [Description("buy")]
    Buy,
    [Description("depositCrypto")]
    DepositCrypto,
    [Description("depositFiat")]
    DepositFiat,
    [Description("sell")]
    Sell,
    [Description("withdrawCrypto")]
    WithdrawCrypto,
    [Description("withdrawFiat")]
    WithdrawFiat
  }
}