namespace PetSitter.Domain.ValueObjects;

public record Disease
{
    public Disease(string name, string condition)
    {
        Name = name;
        Condition = condition;
    }

    public string Name { get; private set; }

    public string Condition { get; private set; }
}