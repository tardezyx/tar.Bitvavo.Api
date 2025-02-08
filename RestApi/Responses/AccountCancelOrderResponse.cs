using System;

namespace tar.Bitvavo.Api.RestApi.Responses {
  public class AccountCancelOrderResponse {
    public string ClientOrderId { get; set; }
    public Guid? OrderId { get; set; }
  }
}