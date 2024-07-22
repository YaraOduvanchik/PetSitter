using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;

namespace PetSitter.Domain.ValueObjects;

public record Vaccination
{
    private Vaccination()
    {

    }

    public Vaccination(string name, DateTimeOffset timeLimit)
    {
        Name = name;
        TimeLimit = timeLimit;
    }

    public string Name { get; private set; }

    public DateTimeOffset TimeLimit { get; private set; }

    public static Result<Vaccination, Error> Create(string name, DateTimeOffset timeLimit)
    {
        var nameValue = name.Trim();

        if (string.IsNullOrWhiteSpace(nameValue))
            return Errors.General.ValueIsInvalid(nameValue);

        if (timeLimit > DateTimeOffset.Now)
            return Errors.General.ValueIsInvalid(nameof(timeLimit));


        return new Vaccination(nameValue, timeLimit);
    }
}