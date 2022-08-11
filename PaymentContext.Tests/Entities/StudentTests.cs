using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentTests
  {
    [TestMethod]
    public void AdicionarAssinatura()
    {
      var subscription = new Subscription(null);
      var student = new Student("Eduardo", "Lima", "123.456.789-00", "edufslima9@gmail.com");
      student.AddSubscription(subscription);
    }
  }
}