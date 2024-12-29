using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<AccountOrderStatus>))]
  public enum AccountOrderStatus {
    [Description("awaitingTrigger")]
    AwaitingTrigger,
    [Description("canceled")]
    Canceled,
    [Description("canceledAuction")]
    CanceledAuction,
    [Description("canceledFOK")]
    CanceledFillOrKill,
    [Description("canceledIOC")]
    CanceledImmediateOrCancel,
    [Description("canceledMarketProtection")]
    CanceledMarketProtection,
    [Description("canceledPostOnly")]
    CanceledPostOnly,
    [Description("canceledSelfTradePrevention")]
    CanceledSelfTradePrevention,
    [Description("expired")]
    Expired,
    [Description("filled")]
    Filled,
    [Description("new")]
    New,
    [Description("partiallyFilled")]
    PartiallyFilled,
    [Description("rejected")]
    Rejected
  }
}