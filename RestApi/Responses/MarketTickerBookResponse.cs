namespace tar.Bitvavo.Api.RestApi.Responses {
  public class MarketTickerBookResponse {
    public decimal? Ask { get; set; }
    public decimal? AskSize { get; set; }
    public decimal? Bid { get; set; }
    public decimal? BidSize { get; set; }
    public string Market { get; set; }
  }
}