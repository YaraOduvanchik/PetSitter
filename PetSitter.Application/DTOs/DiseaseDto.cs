namespace PetSitter.Application.DTOs;

public class DiseaseDto
{
    public Guid Id { get; init; }
    public Guid AnimalId { get; init; }

    public string Name { get; init; } = string.Empty;
    public string Symptom { get; init; } = string.Empty;
}