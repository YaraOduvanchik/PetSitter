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

        if (string.IsNullOrWhiteSpace(cityValue))
            return Errors.General.ValueIsInvalid(cityValue);
        
        if (string.IsNullOrWhiteSpace(streetValue))
            return Errors.General.ValueIsInvalid(streetValue);
        
        if (string.IsNullOrWhiteSpace(buildingValue))
            return Errors.General.ValueIsInvalid(buildingValue);
        
        if (string.IsNullOrWhiteSpace(indexValue))
            return Errors.General.ValueIsInvalid(indexValue);


        return new Address(cityValue, streetValue, buildingValue, indexValue);
    }
}