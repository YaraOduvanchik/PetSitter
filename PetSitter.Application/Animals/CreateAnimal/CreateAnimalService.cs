using CSharpFunctionalExtensions;
using PetSitter.Application.Abstractions;
using PetSitter.Domain.Common;

namespace PetSitter.Application.Animals.CreateAnimal;

public class CreateAnimalService
{
    private readonly IAnimalsRepository _animalsRepository;

    public CreateAnimalService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }

    public async Task<Result<Guid, Error>> Handle(CreateAnimalRequest request, CancellationToken ct)
    {
        var animal = Domain.Entities.Animal.Create(
            request.UserId,
            request.Name,
            request.Description,
            request.TypeKind,
            request.Gender,
            request.Breed,
            request.Birthday,
            request.Weight).Value;

        var idResult = await _animalsRepository.Add(animal, ct);

        if (idResult.IsFailure)
            return idResult.Error;

        return idResult.Value;
    }
}