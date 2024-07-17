using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;

namespace PetSitter.Domain.ValueObjects;

public record Disease
{
    private Disease()
    {
        
    }
    
    private Disease(string name, string condition)
    {
        Name = name;
        Condition = condition;
    }

    public string Name { get; private set; }

    public string Condition { get; private set; }
    
    public static Result<Disease, Error> Create(string name, string condition)
    {
        var nameValue = name.Trim();
        var conditionValue = condition.Trim();

        if (string.IsNullOrWhiteSpace(nameValue))
            return Errors.General.ValueIsInvalid(nameValue);
        
        if (string.IsNullOrWhiteSpace(conditionValue))
            return Errors.General.ValueIsInvalid(conditionValue);


        return new Disease(nameValue, conditionValue);
    }
}