using System;

namespace tar.Bitvavo.Api.RestApi.Responses {
  public class AccountCancelOrderResponse {
    public Guid? ClientOrderId { get; set; }
    public Guid? OrderId { get; set; }
  }
}