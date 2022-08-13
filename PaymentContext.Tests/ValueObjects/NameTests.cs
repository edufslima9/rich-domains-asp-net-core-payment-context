using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
  [TestClass]
  public class NameTests
  {
    // Red, Green, Refactor

    [TestMethod]
    public void ShouldReturnErrorWhenNameLengthIsLowerThanRequired()
    {
      var name = new Name("Ed", "Lima");
      Assert.IsTrue(!name.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenLastNameLengthIsLowerThanRequired()
    {
      var name = new Name("Eduardo", "Lm");
      Assert.IsTrue(!name.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenNameLengthIsGreaterThanRequired()
    {
      var name = new Name("Eduardo felipa da silma lima Eduardo felipa da silma lima", "Lima");
      Assert.IsTrue(!name.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenLastNameLengthIsGreaterThanRequired()
    {
      var name = new Name("Eduardo", "Eduardo felipa da silma lima Eduardo felipa da silma lima");
      Assert.IsTrue(!name.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccess()
    {
      var name = new Name("Eduardo", "Lima");
      Assert.IsTrue(name.IsValid);
    }
  }
}