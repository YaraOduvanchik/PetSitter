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
}