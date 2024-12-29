using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<AccountWithdrawalStatus>))]
  public enum AccountWithdrawalStatus {
    [Description("approved")]
    Approved,
    [Description("awaiting_bitvavo_inspection")]
    AwaitingBitvavoInspection,
    [Description("awaiting_email_confirmation")]
    AwaitingEmailConfirmation,
    [Description("awaiting_processing")]
    AwaitingProcessing,
    [Description("canceled")]
    Canceled,
    [Description("completed")]
    Completed,
    [Description("in_mempool")]
    InMempool,
    [Description("processed")]
    Processed,
    [Description("sending")]
    Sending
  }
}