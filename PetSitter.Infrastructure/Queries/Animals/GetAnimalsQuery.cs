using Microsoft.EntityFrameworkCore;
using PetSitter.Application.Animals.GetAnimals;
using PetSitter.Infrastructure.DbContexts;

namespace PetSitter.Infrastructure.Queries.Animals;

public class GetAnimalsQuery
{
    private readonly PetSitterReadDbContext _dbContext;


    public GetAnimalsQuery(PetSitterReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<GetAnimalsResponse> Handle(GetAnimalsRequest request, CancellationToken ct)
    {
        var animalsQuery = _dbContext.Animals
            .Where(u => string.IsNullOrWhiteSpace(request.Name) || u.Name.Contains(request.Name))
            .Where(u => string.IsNullOrWhiteSpace(request.Gender) || u.Gender.Contains(request.Gender))
            .Where(u => string.IsNullOrWhiteSpace(request.Breed) || u.Breed.Contains(request.Breed))
            .OrderBy(u => u.Birthday);

        var totalCount = await animalsQuery.CountAsync(ct);

        var animals = await animalsQuery.Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .ToListAsync(ct);

        return new(animals, totalCount);
    }
}