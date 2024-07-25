using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;

namespace PetSitter.Application.Features.Diseases;

public interface IDiseaseRepository
{
    Task<Result<Guid, Error>> Add(Disease disease, CancellationToken ct);

    Task<IReadOnlyList<Disease>> Get(CancellationToken ct);
}
