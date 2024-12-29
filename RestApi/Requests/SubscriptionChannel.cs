using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace tar.Bitvavo.Api.RestApi.Requests {
  public class SubscriptionChannel {
    [JsonPropertyName("interval")]
    public List<string> Interval { get; set; }
    [JsonPropertyName("markets")]
    public List<string> Markets { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }

    public SubscriptionChannel(
      List<string> interval = null,
      List<string> markets = null,
      string name = null
    ) {
      Interval = interval;
      Markets = markets;
      Name = name;
    }
  }
}