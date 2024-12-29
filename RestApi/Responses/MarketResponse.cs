using System.Collections.Generic;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.RestApi.Responses {
  public class MarketResponse {
    public string Base { get; set; }
    public string Market { get; set; }
    public decimal? MaxOrderInBaseAsset { get; set; }
    public decimal? MaxOrderInQuoteAsset { get; set; }
    public decimal? MinOrderInBaseAsset { get; set; }
    public decimal? MinOrderInQuoteAsset { get; set; }
    public List<AccountOrderType> OrderTypes { get; set; }
    public int? PricePrecision { get; set; }
    public string Quote { get; set; }
    public MarketStatus? Status { get; set; }
  }
}