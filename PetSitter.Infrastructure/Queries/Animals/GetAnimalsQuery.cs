using Microsoft.EntityFrameworkCore;
using PetSitter.Application.Features.Animals.GetAnimals;
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
            .Where(a => string.IsNullOrWhiteSpace(request.Name) || a.Name.Contains(request.Name))
            .Where(a => string.IsNullOrWhiteSpace(request.Description) || a.Description.Contains(request.Description))
            .Where(a => string.IsNullOrWhiteSpace(request.TypeKind) || a.TypeKind.Contains(request.TypeKind))
            .OrderBy(a => a.Birthday);

        var totalCount = await animalsQuery.CountAsync(ct);

        var animals = await animalsQuery.Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .ToListAsync(ct);

        return new GetAnimalsResponse(animals, totalCount);
    }
}