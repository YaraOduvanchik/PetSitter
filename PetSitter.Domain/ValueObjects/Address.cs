using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;

namespace PetSitter.Domain.ValueObjects;

public record Address
{
    public const int INDEX_TITLE_LENGTH = 6;

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
        city = city.Trim();
        building = building.Trim();
        index = index.Trim();

        if (city.Length is Constraints.MINIMUN_TITLE_LENGTH or > Constraints.SHORT_TITLE_LENGTH)
            return Errors.General.InvalidLength("city");

        if (street.Length is < Constraints.MINIMUN_TITLE_LENGTH or > Constraints.MEDIUM_TITLE_LENGTH)
            return Errors.General.InvalidLength("street");

        if (string.IsNullOrWhiteSpace(building) || building.Length > Constraints.SHORT_TITLE_LENGTH)
            return Errors.General.InvalidLength("building");

        if (index.Length != INDEX_TITLE_LENGTH)
            return Errors.General.InvalidLength("index");


        return new Address(city, street, building, index);
    }
}