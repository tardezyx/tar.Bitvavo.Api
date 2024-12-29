namespace tar.Bitvavo.Api.RestApi.Responses {
  public class AccountBalanceResponse {
    public decimal? Available { get; set; }
    public decimal? InOrder { get; set; }
    public string Symbol { get; set; }
  }
}