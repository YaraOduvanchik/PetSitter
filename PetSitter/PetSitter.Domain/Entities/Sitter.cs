namespace PetSitter.Domain.Entities;

public class Sitter
{
    public string Name { get; set; } = string.Empty;
    
    public string Surname { get; set; } = string.Empty;

    public string Patronymic { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public int Phone {  get; set; }

    public DateTimeOffset DateOfBirth { get; set; }

    public string Reason { get; set; } = string.Empty;

    public string AnimalCount { get; set; } = string.Empty;

    public string Preferences { get; set; } = string.Empty;
}