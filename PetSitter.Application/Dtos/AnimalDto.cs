namespace PetSitter.Application.Dtos;

public class AnimalDto
{
    public Guid Id { get; init; } 
    public Guid UserId { get; init; }
    
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string TypeKind { get; init; } = string.Empty;
    public string Gender { get; init; } = string.Empty;
    public string Breed { get; init; } = string.Empty;
    
    public float Weight { get; init; }
    
    public DateTimeOffset Birthday { get; init; }
    public List<PhotoDto> Photos { get; init; } = [];
}