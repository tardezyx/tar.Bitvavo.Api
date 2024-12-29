using System.Collections.Generic;

namespace tar.Bitvavo.Api.RestApi.Responses {
  public class MarketOrderBookResponse {
    public List<AmountPriceResponse> Asks { get; set; }
    public List<AmountPriceResponse> Bids { get; set; }
    public string Market { get; set; }
    public long? Nonce { get; set; }
  }
}