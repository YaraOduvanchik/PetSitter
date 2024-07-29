using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;

namespace PetSitter.Application.Features.Animals;

public interface IAnimalRepository
{
    Task<Result<Guid, Error>> Add(Animal animal, CancellationToken ct);

    Task<Result<Animal, Error>> GetById(Guid id, CancellationToken ct);

    Task<Result<int, Error>> Save(CancellationToken ct);
}