using System;
using System.Net.WebSockets;
using tar.Bitvavo.Api.WebSocketApi.Receives;
using tar.Bitvavo.Api.WebSocketApi.Sends;
using tar.WebSocket;

namespace tar.Bitvavo.Api.WebSocketApi {
  public class CallbackInfo {
    public TimeSpan AccessWindow { get; set; }
    public WebSocketClientAction ClientAction { get; set; }
    public string ClientActionDescription { get; set; } = string.Empty;
    public DateTime? Closed { get; set; }
    public TimeSpan? Duration { get; set; }
    public string ErrorMessage { get; set; }
    public DateTime? LastAuthed { get; set; }
    public DateTime? Opened { get; set; }
    public ReceiveMessage ReceivedMessage { get; set; }
    public string SentMessage { get; set; }
    public SendOptions SentOptions { get; set; }
    public SendPayload SentPayload { get; set; }
    public WebSocketState? State { get; set; }
    public string StateDescription { get; set; }
    public bool Success { get; set; } = false;
    public DateTime Timestamp { get; set; }
    public bool TriggeredByClient { get; set; } = true;
    public string Url { get; set; } = string.Empty;
  }
}