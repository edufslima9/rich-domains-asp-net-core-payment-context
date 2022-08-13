using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
  public class Address : ValueObject
  {
    public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
    {
      Street = street;
      Number = number;
      Neighborhood = neighborhood;
      City = city;
      State = state;
      Country = country;
      ZipCode = zipCode;

      AddNotifications(new Contract<Address>()
        .Requires()
        .IsLowerThan(Street, 3, "Address.Street", "Rua deve conter pelo menos 3 caracteres")
        .IsLowerThan(Number, 1, "Address.Number", "Rua deve conter pelo menos 1 caracteres")
        .IsLowerThan(Neighborhood, 3, "Address.Neighborhood", "Bairro deve conter pelo menos 3 caracteres")
        .IsLowerThan(City, 3, "Address.City", "Cidade deve conter pelo menos 3 caracteres")
        .IsLowerThan(State, 3, "Address.State", "Estado deve conter pelo menos 3 caracteres")
        .IsLowerThan(Country, 3, "Address.Country", "País deve conter pelo menos 3 caracteres")
        .IsLowerThan(ZipCode, 3, "Address.ZipCode", "CEP deve conter pelo menos 3 caracteres")
      );
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
  }
}