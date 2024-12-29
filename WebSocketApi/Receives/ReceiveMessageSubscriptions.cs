using System.Collections.Generic;

namespace tar.Bitvavo.Api.WebSocketApi.Receives {
  public class ReceiveMessageSubscriptions {
    public List<string> Account { get; set; }
    public List<string> Book { get; set; }
    public ReceiveMessageSubscriptionsCandles Candles { get; set; }
    public List<string> Ticker { get; set; }
    public List<string> Ticker24h { get; set; }
    public List<string> Trades { get; set; }
  }
}