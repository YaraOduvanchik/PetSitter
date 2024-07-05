namespace PetSitter.Domain.Entities;

public class User
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string Patronymic { get; set; } = string.Empty;

    public int Phone { get; set; }

    public DateTimeOffset DateOfBirth { get; set; }

    public string Address { get; set; } = string.Empty;
}