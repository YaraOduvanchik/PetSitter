using Microsoft.EntityFrameworkCore;
using PetSitter.Application.Features.Sitters.GetSitters;
using PetSitter.Infrastructure.DbContexts;

namespace PetSitter.Infrastructure.Queries.Sitters;

public class GetSittersQuery
{
    private readonly PetSitterReadDbContext _dbContext;

    public GetSittersQuery(PetSitterReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetSittersResponse> Handle(GetSittersRequest request, CancellationToken ct)
    {
        var sittersQuery = _dbContext.Sitters
            .Where(u => string.IsNullOrWhiteSpace(request.Name) || u.Name.Contains(request.Name))
            .Where(u => string.IsNullOrWhiteSpace(request.Surname) || u.Surname.Contains(request.Surname))
            .Where(u => string.IsNullOrWhiteSpace(request.Patronymic) || u.Patronymic.Contains(request.Patronymic))
            .OrderBy(u => u.DateOfBirth);

        var totalCount = await sittersQuery.CountAsync(ct);

        var sitters = await sittersQuery.Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .ToListAsync(ct);

        return new GetSittersResponse(sitters, totalCount);
    }
}