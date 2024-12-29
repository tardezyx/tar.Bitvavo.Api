using System.Collections.Generic;
using tar.Bitvavo.Api.Enums;

namespace tar.Bitvavo.Api.RestApi.Responses {
  public class AccountResponse {
    public List<AccountCapability> Capabilities { get; set; }
    public AccountFeesResponse Fees { get; set; }
  }
}