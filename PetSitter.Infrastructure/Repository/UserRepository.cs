using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetSitter.Application.Abstractions;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;
using PetSitter.Infrastructure.DbContexts;

namespace PetSitter.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly PetSitterWriteDbContext _dbContext;

    public UserRepository(PetSitterWriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<Guid, Error>> Add(User user, CancellationToken ct)
    {
        await _dbContext.AddAsync(user, ct);

        var result = await _dbContext.SaveChangesAsync(ct);

        if (result == 0)
        {
            return new Error("record.save", "User can not be save");
        }

        return user.Id;
    }

    public async Task<Result<User, Error>> GetUsersById(Guid id, CancellationToken ct)
    {
        var user = await _dbContext.Users.FindAsync(id);

        if (user is null)
            return Errors.General.NotFound();

        return user;
    }

    public async Task<IReadOnlyList<User>> Get(CancellationToken ct)
    {
        return await _dbContext.Users.AsNoTracking().ToListAsync(ct);
    }
}