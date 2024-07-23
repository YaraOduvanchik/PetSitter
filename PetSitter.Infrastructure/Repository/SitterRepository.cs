using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetSitter.Application.Features.Sitters;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;
using PetSitter.Infrastructure.DbContexts;

namespace PetSitter.Infrastructure.Repository;

public class SitterRepository : ISitterRepository
{
    private readonly PetSitterWriteDbContext _dbContext;

    public SitterRepository(PetSitterWriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<Guid, Error>> Add(Sitter sitter, CancellationToken ct)
    {
        await _dbContext.Sitters.AddAsync(sitter, ct);

        var result = await _dbContext.SaveChangesAsync(ct);

        if (result == 0)
            return Errors.General.CantSave("Sitter");

        return sitter.Id;
    }

    public async Task<IReadOnlyList<Sitter>> Get(CancellationToken ct)
    {
        return await _dbContext.Sitters.AsNoTracking().ToListAsync(ct);
    }
}