using CSharpFunctionalExtensions;
using PetSitter.Application.Abstractions;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;

namespace PetSitter.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly PetSitterDbContext _context;

    public UserRepository(PetSitterDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid, Error>> Add(User user, CancellationToken ct)
    {
        await _context.AddAsync(user, ct);

        var result = await _context.SaveChangesAsync(ct);

        if (result == 0)
        {
            return new Error("record.save", "User can not be save");
        }

        return user.Id;
    }
}