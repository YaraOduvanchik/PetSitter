using CSharpFunctionalExtensions;
using PetSitter.Application.Features.Animals;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;
using PetSitter.Infrastructure.DbContexts;

namespace PetSitter.Infrastructure.Repository;

public class AnimalRepository : IAnimalsRepository
{
    private readonly PetSitterWriteDbContext _context;

    public AnimalRepository(PetSitterWriteDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid, Error>> Add(Animal animal, CancellationToken ct)
    {
        await _context.AddAsync(animal, ct);

        var result = await _context.SaveChangesAsync(ct);

        if (result == 0)
            return Errors.General.CantSave("Animal");

        return animal.Id;
    }
}