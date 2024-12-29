using System;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.RestApi.Responses {
  public class ServerTimeResponse {
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? Time { get; set; }
  }
}