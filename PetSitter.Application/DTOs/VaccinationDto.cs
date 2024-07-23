namespace PetSitter.Application.DTOs;

public class VaccinationDto
{
    public Guid Id { get; init; }
    public Guid AnimalId { get; init; }

    public string Name { get; init; } = string.Empty;

    public int DurationDay { get; init; }

    public bool IsTimeLimit { get; init; }
}