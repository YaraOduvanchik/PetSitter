using PetSitter.Application.Dtos;

namespace PetSitter.Application.Animals.GetAnimals;

public record GetAnimalsResponse(IEnumerable<AnimalDto> Animals, int TotalCount);