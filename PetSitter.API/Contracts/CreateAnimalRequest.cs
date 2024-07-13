using PetSitter.Domain.Entities;
using PetSitter.Domain.ValueObjects;

namespace PetSitter.API.Contracts;

public record CreateAnimalRequest(
    Guid Id,
    string Name,
    string Description,
    Gender Gender,
    int Age,
    Kind Kind,
    string Breed,
    float Weight);