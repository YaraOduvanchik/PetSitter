using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;

namespace PetSitter.Application.Abstractions;

public interface IAnimalsRepository
{
    Task<Result<Guid, Error>> Add(Domain.Entities.Animal animal, CancellationToken ct);
}