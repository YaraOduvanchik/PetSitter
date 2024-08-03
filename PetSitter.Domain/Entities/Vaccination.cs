using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;
using Entity = PetSitter.Domain.Common.Entity;

namespace PetSitter.Domain.Entities;

public class Vaccination: Entity
{
    private Vaccination()
    {
    }

    private Vaccination(string name, int durationDay, bool isTimeLimit)
    {
        Name = name;
        DurationDay = durationDay;
        IsTimeLimit = isTimeLimit;
    }
    
    public string Name { get; private set; }
    public int DurationDay { get; private set; }
    public bool IsTimeLimit { get; private set; }

    public static Result<Vaccination, Error> Create(string name, int durationDay, bool isTimeLimit)
    {
        var nameValue = name.Trim();

        if (string.IsNullOrWhiteSpace(nameValue))
            return Errors.General.ValueIsInvalid(nameValue);

        if (durationDay < 1)
            return Errors.General.ValueIsInvalid(nameof(durationDay));

        if (isTimeLimit is false)
            durationDay = 0;

        return new Vaccination(nameValue, durationDay, isTimeLimit);
    }
}