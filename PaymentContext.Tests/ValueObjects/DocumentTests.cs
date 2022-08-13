using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
  [TestClass]
  public class DocumentTests
  {
      // Red, Green, Refactor

      [TestMethod]
      public void ShouldReturnErrorWhenCNPJIsInvalid()
      {
        var doc = new Document("123", EDocumentType.CNPJ);
        Assert.IsTrue(!doc.IsValid);
      }

      
      [TestMethod]
      public void ShouldReturnSuccessWhenCNPJIsValid()
      {
        var doc = new Document("29424682000141", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
      }

      [TestMethod]
      public void ShouldReturnErrorWhenCPFIsInvalid()
      {
        var doc = new Document("123", EDocumentType.CPF);
        Assert.IsTrue(!doc.IsValid);
      }

      
      [TestMethod]
      public void ShouldReturnSuccessWhenCPFIsValid()
      {
        var doc = new Document("11355443440", EDocumentType.CPF);
        Assert.IsTrue(doc.IsValid);
      }
  }
}