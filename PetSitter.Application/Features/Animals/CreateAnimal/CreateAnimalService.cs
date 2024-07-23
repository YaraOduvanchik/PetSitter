using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;

namespace PetSitter.Application.Features.Animals.CreateAnimal;

public class CreateAnimalService
{
    private readonly IAnimalsRepository _animalsRepository;

    public CreateAnimalService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }

    public async Task<Result<Guid, Error>> Handle(CreateAnimalRequest request, CancellationToken ct)
    {
        var photos = request.Photos.Select(p => Photo.Create(p.Path, p.IsMain).Value);
        var diseases = request.Diseases.Select(d => Disease.Create(d.Name, d.Symptom).Value);
        var vaccinations =
            request.Vaccinations.Select(v => Vaccination.Create(v.Name, v.DurationDay, v.IsTimeLimit).Value);

        var animal = Animal.Create(
            request.UserId,
            request.Name,
            request.Description,
            request.TypeKind,
            request.Gender,
            request.Breed,
            request.Birthday,
            request.Weight,
            [],
            [],
            []
        ).Value;

        var idResult = await _animalsRepository.Add(animal, ct);

        if (idResult.IsFailure)
            return idResult.Error;

        return idResult.Value;
    }
}