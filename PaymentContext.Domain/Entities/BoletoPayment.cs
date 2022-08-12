using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
  public class BoletoPayment : Payment
  {
    public BoletoPayment(string barCode, string boletoNumber, Email email, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Document document, Address address) : base(paidDate, expireDate, total, totalPaid, payer, document, address)
    {
      BarCode = barCode;
      BoletoNumber = boletoNumber;
      Email = email;
    }

    public string BarCode { get; private set; }
    public string BoletoNumber { get; private set; }
    public Email Email { get; private set; }
  }
}