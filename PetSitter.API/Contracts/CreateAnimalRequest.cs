using PetSitter.Domain.Entities;
using PetSitter.Domain.ValueObjects;

namespace PetSitter.API.Contracts;

public record CreateAnimalRequest(
    Guid Id,
    Guid UserId,
    string Name,
    string Description,
    string TypeKind,
    string Gender,
    int Age,
    string Breed,
    float Weight);