using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;

namespace PetSitter.Application.Abstractions;

public interface IAnimalsRepository
{
    Task<Result<Guid, Error>> Add(Animal animal, CancellationToken ct);
}