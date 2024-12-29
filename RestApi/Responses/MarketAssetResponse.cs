using System.Collections.Generic;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.RestApi.Responses {
  public class MarketAssetResponse {
    public int? Decimals { get; set; }
    public int? DepositConfirmations { get; set; }
    public decimal? DepositFee { get; set; }
    public MarketAssetStatus? DepositStatus { get; set; }
    public string Message { get; set; }
    public string Name { get; set; }
    public List<string> Networks { get; set; }
    public string Symbol { get; set; }
    public decimal? WithdrawalFee { get; set; }
    public decimal? WithdrawalMinAmount { get; set; }
    public MarketAssetStatus? WithdrawalStatus { get; set; }
  }
}