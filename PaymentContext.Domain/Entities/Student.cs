using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
  public class Student : Entity
  {
    private IList<Subscription> _subscriptions;

    public Student(Name name, string lastName, Document document, Email email)
    {
      Name = name;
      Document = document;
      Email = email;
      _subscriptions = new List<Subscription>();
    }

    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

    public void AddSubscription(Subscription subscription)
    {
      // Se já tiver uma assinatura ativa, não adicionar assinatura nova

      // Cancela todas as outras assinaturas, e colocar esta como principal
      foreach(var sub in Subscriptions)
        sub.Inactivate();

      _subscriptions.Add(subscription);
    }
  }
}