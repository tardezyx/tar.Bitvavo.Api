using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<AccountOrderSelfTradePrevention>))]
  public enum AccountOrderSelfTradePrevention {
    [Description("cancelBoth")]
    CancelBoth,
    [Description("cancelNewest")]
    CancelNewest,
    [Description("cancelOldest")]
    CancelOldest,
    [Description("decrementAndCancel")]
    DecrementAndCancel
  }
}