using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.ValueObjects
{
  [TestClass]
  public class SubscriptionHandlerTests
  {
      // Red, Green, Refactor

      [TestMethod]
      public void ShouldReturnErrorWhenDocumentExists()
      {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "Bruce";
        command.LastName = "Wayne";
        command.Document = "99999999999";
        command.Email = "bruce@wayne.com";
        command.BarCode = "7894561230";
        command.BoletoNumber = "561897058080840040780840";
        command.PaymentNumber = "123121";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddMonths(1);
        command.Total = 60;
        command.TotalPaid = 60;
        command.Payer = "Wayne Corp";
        command.PayerDocument = "1234567891011";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail = "batman@dc.com";
        command.Street = "asdasd";
        command.Number = "asdasd";
        command.Neighborhood = "asdasd";
        command.City = "asdasd";
        command.State = "asdasd";
        command.Country = "asdasd";
        command.ZipCode = "12345678";

        handler.Handle(command);
        Assert.AreEqual(false, handler.IsValid);
      }
  }
}