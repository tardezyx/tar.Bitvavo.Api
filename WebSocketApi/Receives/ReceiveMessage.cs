using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.WebSocketApi.Receives {
  public class ReceiveMessage {
    public WebSocketAction? Action { get; set; }
    public bool? Authenticated { get; set; }
    public ReceiveMessageData Data { get; set; }
    public string Error { get; set; }
    public int? ErrorCode { get; set; }
    public WebSocketEvent? Event { get; set; }
    public ReceiveMessageSubscriptions Subscriptions { get; set; }
    public ReceiveMessageSubscriptionData SubscriptionData { get; set; }
    public long? RequestId { get; set; }
  }
}