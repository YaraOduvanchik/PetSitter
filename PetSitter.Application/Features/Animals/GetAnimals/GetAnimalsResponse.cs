using PetSitter.Application.DTOs;

namespace PetSitter.Application.Features.Animals.GetAnimals;

public record GetAnimalsResponse(IEnumerable<AnimalDto> Animals, int TotalCount);