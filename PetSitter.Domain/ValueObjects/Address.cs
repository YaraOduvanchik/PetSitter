using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;

namespace PetSitter.Domain.ValueObjects;

public record Address
{
    private Address()
    {

    }

    private Address(string city, string street, string building, string index)
    {
        City = city;
        Street = street;
        Building = building;
        Index = index;
    }

    public string City { get; }

    public string Street { get; }

    public string Building { get; }

    public string Index { get; }

    public static Result<Address, Error> Create(string city, string street, string building, string index)
    {
        var cityValue = city.Trim();
        var streetValue = street.Trim();
        var buildingValue = building.Trim();
        var indexValue = index.Trim();

        if (cityValue.Length is < 1 or > 100)
            return Errors.General.InvalidLength("city");

        if (streetValue.Length is < 1 or > 100)
            return Errors.General.InvalidLength("street");

        if (buildingValue.Length is < 1 or > 100)
            return Errors.General.InvalidLength("building");

        if (indexValue.Length != 6)
            return Errors.General.InvalidLength("index");


        return new Address(cityValue, streetValue, buildingValue, indexValue);
    }
}   