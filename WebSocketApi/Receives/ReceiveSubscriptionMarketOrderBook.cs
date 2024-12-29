using System.Collections.Generic;
using tar.Bitvavo.Api.RestApi.Responses;

namespace tar.Bitvavo.Api.WebSocketApi.Receives {
  public class ReceiveSubscriptionMarketOrderBook {
    public List<AmountPriceResponse> Asks { get; set; }
    public List<AmountPriceResponse> Bids { get; set; }
    public string Market { get; set; }
    public long? Nonce { get; set; }
  }
}