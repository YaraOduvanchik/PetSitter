using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetSitter.Application.Features.Animals;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;
using PetSitter.Infrastructure.DbContexts;

namespace PetSitter.Infrastructure.Repository;

public class AnimalRepository : IAnimalRepository
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

    public async Task<Result<Animal, Error>> GetById(Guid id, CancellationToken ct)
    {
        var application = await _context.Animals
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken: ct);

        if (application is null)
            return Errors.General.NotFound(id);

        return application;
    }

    public async Task<Result<int, Error>> Save(CancellationToken ct)
    {
        var result = await _context.SaveChangesAsync();

        if (result == 0)
            return Errors.General.SaveFailure();

        return result;
    }
}