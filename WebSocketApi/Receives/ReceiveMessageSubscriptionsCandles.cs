using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace tar.Bitvavo.Api.WebSocketApi.Receives {
  public class ReceiveMessageSubscriptionsCandles {
    [JsonPropertyName("1m")]
    public List<string> _1m { get; set; }
    [JsonPropertyName("5m")]
    public List<string> _5m { get; set; }
    [JsonPropertyName("15m")]
    public List<string> _15m { get; set; }
    [JsonPropertyName("30m")]
    public List<string> _30m { get; set; }
    [JsonPropertyName("1h")]
    public List<string> _1h { get; set; }
    [JsonPropertyName("2h")]
    public List<string> _2h { get; set; }
    [JsonPropertyName("4h")]
    public List<string> _4h { get; set; }
    [JsonPropertyName("6h")]
    public List<string> _6h { get; set; }
    [JsonPropertyName("8h")]
    public List<string> _8h { get; set; }
    [JsonPropertyName("12h")]
    public List<string> _12h { get; set; }
    [JsonPropertyName("1d")]
    public List<string> _1d { get; set; }
  };
}