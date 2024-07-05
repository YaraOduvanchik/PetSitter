namespace PetSitter.Domain.ValueObjects;

public class Vaccination
{
    public string Name { get; set; } = string.Empty;

    public DateTimeOffset TimeLimit { get; set; }
}