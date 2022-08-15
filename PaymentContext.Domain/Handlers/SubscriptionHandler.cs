using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
  public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionCommand>, IHandler<CreatePaypalSubscriptionCommand>, IHandler<CreateCreditCardSubscriptionCommand>
  {
    private readonly IStudentRepository _repository;
    private readonly IEmailService _emailService;

    public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
    {
      _repository = repository;
      _emailService = emailService;
    }

    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
      // Fail fast validations
      command.Validate();
      if (!command.IsValid)
      {
        AddNotifications(command);
        return new CommandResult(false, "Não foi possível realizar sua assinatura");
      }

      // Verificar se Documento já está cadastrado
      if (_repository.DocumentExists(command.Document))
        AddNotification("Document", "Este CPF já está em uso");

      // Verificar se e-mail já está cadastrado
      if (_repository.EmailExists(command.Email))
        AddNotification("Email", "Este Email já está em uso");

      // Gerar os VOs
      var name = new Name(command.FirstName, command.LastName);
      var document = new Document(command.Document, EDocumentType.CPF);
      var email = new Email(command.Email);
      var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

      // Gerar as Entidades
      var student = new Student(name, document, email);
      var subscription = new Subscription(DateTime.Now.AddMonths(1));
      var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, email, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.PayerDocument, command.PayerDocumentType), address);

      // Relacionamentos
      subscription.AddPayment(payment);
      student.AddSubscription(subscription);

      // Aplicar as validações
      AddNotifications(name, document, email, address, student, subscription, payment);

      // Checar as notificações
      if (!IsValid)
        return new CommandResult(false, "Não foi possível realizar sua assinatura");

      // Salvar as informações
      _repository.CreateSubscription(student);

      // Enviar e-mail de boas vindas
      _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo!", "Sua assinatura foi criada");

      // Retornar informações
      return new CommandResult(true, "Assinatura realizada com sucesso!");
    }

    public ICommandResult Handle(CreatePaypalSubscriptionCommand command)
    {
      // Fail fast validations
      command.Validate();
      if (!command.IsValid)
      {
        AddNotifications(command);
        return new CommandResult(false, "Não foi possível realizar sua assinatura");
      }

      // Verificar se Documento já está cadastrado
      if (_repository.DocumentExists(command.Document))
        AddNotification("Document", "Este CPF já está em uso");

      // Verificar se e-mail já está cadastrado
      if (_repository.EmailExists(command.Email))
        AddNotification("Email", "Este Email já está em uso");

      // Gerar os VOs
      var name = new Name(command.FirstName, command.LastName);
      var document = new Document(command.Document, EDocumentType.CPF);
      var email = new Email(command.Email);
      var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

      // Gerar as Entidades
      var student = new Student(name, document, email);
      var subscription = new Subscription(DateTime.Now.AddMonths(1));
      var payment = new PayPalPayment(email, command.TransactionCode, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.PayerDocument, command.PayerDocumentType), address);

      // Relacionamentos
      subscription.AddPayment(payment);
      student.AddSubscription(subscription);

      // Aplicar as validações
      AddNotifications(name, document, email, address, student, subscription, payment);

      // Checar as notificações
      if (!IsValid)
        return new CommandResult(false, "Não foi possível realizar sua assinatura");

      // Salvar as informações
      _repository.CreateSubscription(student);

      // Enviar e-mail de boas vindas
      _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo!", "Sua assinatura foi criada");

      // Retornar informações
      return new CommandResult(true, "Assinatura realizada com sucesso!");
    }

    public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
    {
      // Fail fast validations
      command.Validate();
      if (!command.IsValid)
      {
        AddNotifications(command);
        return new CommandResult(false, "Não foi possível realizar sua assinatura");
      }

      // Verificar se Documento já está cadastrado
      if (_repository.DocumentExists(command.Document))
        AddNotification("Document", "Este CPF já está em uso");

      // Verificar se e-mail já está cadastrado
      if (_repository.EmailExists(command.Email))
        AddNotification("Email", "Este Email já está em uso");

      // Gerar os VOs
      var name = new Name(command.FirstName, command.LastName);
      var document = new Document(command.Document, EDocumentType.CPF);
      var email = new Email(command.Email);
      var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

      // Gerar as Entidades
      var student = new Student(name, document, email);
      var subscription = new Subscription(DateTime.Now.AddMonths(1));
      var payment = new CreditCardPayment(command.CardHolderName, command.CardNumber, command.LastTransactionNumber, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.PayerDocument, command.PayerDocumentType), address);

      // Relacionamentos
      subscription.AddPayment(payment);
      student.AddSubscription(subscription);

      // Aplicar as validações
      AddNotifications(name, document, email, address, student, subscription, payment);

      // Checar as notificações
      if (!IsValid)
        return new CommandResult(false, "Não foi possível realizar sua assinatura");

      // Salvar as informações
      _repository.CreateSubscription(student);

      // Enviar e-mail de boas vindas
      _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo!", "Sua assinatura foi criada");

      // Retornar informações
      return new CommandResult(true, "Assinatura realizada com sucesso!");
    }
  }
}