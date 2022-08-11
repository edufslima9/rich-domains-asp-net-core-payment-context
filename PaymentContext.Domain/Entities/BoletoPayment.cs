namespace PaymentContext.Domain.Entities
{
  public class BoletoPayment : Payment
  {
    public BoletoPayment(string barCode, string boletoNumber, string email, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string document, string address) : base(paidDate, expireDate, total, totalPaid, payer, document, address)
    {
      BarCode = barCode;
      BoletoNumber = boletoNumber;
      Email = email;
    }

    public string BarCode { get; private set; }
    public string BoletoNumber { get; private set; }
    public string Email { get; private set; }
  }
}