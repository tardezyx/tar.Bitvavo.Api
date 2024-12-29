using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<AccountTransactionType>))]
  public enum AccountTransactionType {
    [Description("affiliate")]
    Affiliate,
    [Description("buy")]
    Buy,
    [Description("deposit")]
    Deposit,
    [Description("distribution")]
    Distribution,
    [Description("external_transferred_funds")]
    ExternalTransferredFunds,
    [Description("internal_transfer")]
    InternalTransfer,
    [Description("loan")]
    Loan,
    [Description("rebate")]
    Rebate,
    [Description("sell")]
    Sell,
    [Description("staking")]
    Staking,
    [Description("withdrawal")]
    Withdrawal,
    [Description("withdrawal_cancelled")]
    WithdrawalCancelled
  }
}