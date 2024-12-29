using System.ComponentModel;
using System.Text.Json.Serialization;
using tar.Bitvavo.Api.Converters;

namespace tar.Bitvavo.Api.Enums {
  [JsonConverter(typeof(EnumConverter<WebSocketEvent>))]
  public enum WebSocketEvent {
    [Description("authenticate")]
    Authenticate,
    [Description("book")]
    Book,
    [Description("candle")]
    Candle,
    [Description("fill")]
    Fill,
    [Description("order")]
    Order,
    [Description("subscribed")]
    Subscribed,
    [Description("ticker")]
    Ticker,
    [Description("ticker24h")]
    Ticker24h,
    [Description("trade")]
    Trade,
    [Description("unauthenticate")]
    Unauthenticate,
    [Description("unsubscribed")]
    Unsubscribed,
  }
}