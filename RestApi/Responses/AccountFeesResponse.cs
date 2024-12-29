namespace tar.Bitvavo.Api.RestApi.Responses {
  public class AccountFeesResponse {
    public decimal? Maker { get; set; }
    public decimal? Taker { get; set; }
    public int? Tier { get; set; }
    public decimal? Volume { get; set; }
  }
}