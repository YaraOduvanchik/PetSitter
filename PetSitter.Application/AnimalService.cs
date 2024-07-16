using Contracts;
using CSharpFunctionalExtensions;
using PetSitter.Application.Abstractions;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;

namespace PetSitter.Application;

public class AnimalService
{
    private readonly IAnimalsRepository _repository;

    public AnimalService(IAnimalsRepository repository)
    {
        _repository = repository;
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

        var idResult = await _repository.Add(animal.Value, ct);

        if (idResult.IsFailure)
        {
            return idResult.Error;
        }

        return idResult.Value;
    }
}