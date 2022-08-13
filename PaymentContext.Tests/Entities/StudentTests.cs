using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentTests
  {
    private readonly Name _name;
    private readonly Document _document;
    private readonly Email _email;
    private readonly Address _address;
    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
      _name = new Name("Bruce", "Wayne");
      _document = new Document("46875364174", EDocumentType.CPF);
      _email = new Email("wayne.bruce@dc.com");
      _address = new Address("Street 1", "2087", "Bristol", "Gothan", "New York", "USA", "784950025");
      _student = new Student(_name, _document, _email);
      _subscription = new Subscription(null);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
      var payment = new PayPalPayment(_email, "12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Wayne CORP", _document, _address);

      _subscription.AddPayment(payment);
      _student.AddSubscription(_subscription);
      _student.AddSubscription(_subscription);

      Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadSubscriptionHasNoPayment()
    {
      _student.AddSubscription(_subscription);

      Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAddSubscription()
    {
      var payment = new PayPalPayment(_email, "12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Wayne CORP", _document, _address);

      _subscription.AddPayment(payment);
      _student.AddSubscription(_subscription);

      Assert.IsTrue(_student.IsValid);
    }
  }
}