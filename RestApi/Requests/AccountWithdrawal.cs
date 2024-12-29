namespace tar.Bitvavo.Api.RestApi.Requests {
  public class AccountWithdrawal {
    public string Address { get; }
    public bool AddWithdrawalFee { get; }
    public decimal Amount { get; }
    public string PaymentId { get; }
    public string Symbol { get; }

    public AccountWithdrawal(
      string address,
      decimal amount,
      string symbol,
      bool addWithdrawalFee = false,
      string paymentId = ""
    ) {
      Address = address;
      AddWithdrawalFee = addWithdrawalFee;
      Amount = amount;
      PaymentId = paymentId;
      Symbol = symbol;
    }
  }
}