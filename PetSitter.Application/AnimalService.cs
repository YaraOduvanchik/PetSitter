using Contracts;
using Contracts.Requests;
using CSharpFunctionalExtensions;
using PetSitter.Application.Abstractions;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;

namespace PetSitter.Application;

public class AnimalService
{
    private readonly IAnimalsRepository _animalsRepository;

    public AnimalService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }

    public async Task<Result<Guid, Error>> CreateAnimal(CreateAnimalRequest request, CancellationToken ct)
    {
        var animal = Animal.Create(
            Guid.Empty,
            request.Name,
            request.Description,
            request.TypeKind,
            request.Gender,
            request.Breed,
            request.Birthday,
            request.Weight);

        var idResult = await _animalsRepository.Add(animal.Value, ct);

        if (idResult.IsFailure)
            return idResult.Error;

        return idResult.Value;
    }
}