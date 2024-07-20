namespace Contracts.Requests;

public record CreateAnimalRequest(
    Guid UserId,
    string Name,
    string Description,
    string TypeKind,
    string Gender,
    string Breed,
    DateTimeOffset Birthday,
    float Weight);