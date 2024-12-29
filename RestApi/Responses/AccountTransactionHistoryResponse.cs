using System.Collections.Generic;

namespace tar.Bitvavo.Api.RestApi.Responses {
  public class AccountTransactionHistoryResponse {
    public int? CurrentPage { get; set; }
    public List<AccountTransactionHistoryResponseItem> Items { get; set; }
    public int? MaxItems { get; set; }
    public int? TotalPages { get; set; }
  }
}