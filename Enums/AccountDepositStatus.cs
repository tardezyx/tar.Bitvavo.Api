using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<AccountDepositStatus>))]
  public enum AccountDepositStatus {
    [Description("canceled")]
    Canceled,
    [Description("completed")]
    Completed
  }
}