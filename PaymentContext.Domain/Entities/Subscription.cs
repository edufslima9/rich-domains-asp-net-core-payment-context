using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
  public class Subscription : Entity
  {
    private IList<Payment> _payments;

    public Subscription(DateTime? exireDate)
    {
      CreateDate = DateTime.Now;
      LastUpdateDate = DateTime.Now;
      ExireDate = exireDate;
      Active = true;
      _payments = new List<Payment>();
    }

    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public DateTime? ExireDate { get; private set; }
    public bool Active { get; private set; }
    public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

    public void AddPayment(Payment payment)
    {
      AddNotifications(new Contract<Subscription>()
        .Requires()
        .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "A data do pagamento deve ser futura")
      );

      _payments.Add(payment);
    }

    public void Activate()
    {
      Active = true;
      LastUpdateDate = DateTime.Now;
    }

    public void Inactivate()
    {
      Active = false;
      LastUpdateDate = DateTime.Now;
    }
  }
}