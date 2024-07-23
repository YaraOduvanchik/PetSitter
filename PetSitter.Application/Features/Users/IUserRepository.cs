using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;

namespace PetSitter.Application.Features.Users;

public interface IUserRepository
{
    Task<Result<Guid, Error>> Add(User user, CancellationToken ct);
    Task<IReadOnlyList<User>> Get(CancellationToken ct);
}