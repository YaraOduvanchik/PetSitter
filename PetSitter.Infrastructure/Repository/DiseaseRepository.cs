using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetSitter.Application.Features.Diseases;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;
using PetSitter.Infrastructure.DbContexts;

namespace PetSitter.Infrastructure.Repository;

public class DiseaseRepository : IDiseaseRepository
{
    private readonly PetSitterWriteDbContext _dbContext;

    public DiseaseRepository(PetSitterWriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<Guid, Error>> Add(Disease disease, CancellationToken ct)
    {
        await _dbContext.Diseases.AddAsync(disease, ct);

        var result = await _dbContext.SaveChangesAsync(ct);

        if (result == 0)
            return Errors.General.CantSave("Disease");

        return disease.Id;
    }

    public async Task<IReadOnlyList<Disease>> Get(CancellationToken ct)
    {
        return await _dbContext.Diseases.AsNoTracking().ToListAsync(ct);
    }
}