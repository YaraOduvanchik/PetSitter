using Microsoft.EntityFrameworkCore;
using PetSitter.Application.Features.Diseases.GetDiseases;
using PetSitter.Infrastructure.DbContexts;

namespace PetSitter.Infrastructure.Queries.Disease;

public class GetDiseasesQuery
{
    private readonly PetSitterReadDbContext _dbContext;

    public GetDiseasesQuery(PetSitterReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetDiseasesResponse> Handle(GetDiseasesRequest request, CancellationToken ct)
    {
        var diseasesQuery = _dbContext.Diseases
            .Where(a => string.IsNullOrWhiteSpace(request.Name) || a.Name.Contains(request.Name))
            .Where(a => string.IsNullOrWhiteSpace(request.Symptoms) || a.Symptom.Contains(request.Symptoms))
            .OrderBy(a => a.Name);

        var totalCount = await diseasesQuery.CountAsync(ct);

        var diseases = await diseasesQuery.Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .ToListAsync(ct);

        return new GetDiseasesResponse(diseases, totalCount);
    }
}