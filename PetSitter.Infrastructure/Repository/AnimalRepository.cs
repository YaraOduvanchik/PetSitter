using CSharpFunctionalExtensions;
using PetSitter.Application.Abstractions;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;

namespace PetSitter.Infrastructure.Repository;

public class AnimalRepository : IAnimalsRepository
{
    private readonly PetSitterDbContext _context;

    public AnimalRepository(PetSitterDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid, Error>> Add(Animal animal, CancellationToken ct)
    {
        await _context.AddAsync(animal, ct);

        var result = await _context.SaveChangesAsync(ct);

        if (result == 0)
        {
            return new Error("record.save", "Animal can not be save");
        }

        return animal.Id;
    }
}