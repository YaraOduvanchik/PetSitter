using Microsoft.EntityFrameworkCore;
using PetSitter.Application.Features.Users.GetUsers;
using PetSitter.Infrastructure.DbContexts;

namespace PetSitter.Infrastructure.Queries.Users;

public class GetUsersQuery
{
    private readonly PetSitterReadDbContext _dbContext;

    public GetUsersQuery(PetSitterReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken ct)
    {
        var usersQuery = _dbContext.Users
            .Where(u => string.IsNullOrWhiteSpace(request.Name) || u.Name.Contains(request.Name))
            .Where(u => string.IsNullOrWhiteSpace(request.Surname) || u.Surname.Contains(request.Surname))
            .Where(u => string.IsNullOrWhiteSpace(request.Patronymic) || u.Patronymic.Contains(request.Patronymic))
            .OrderBy(u => u.DateOfBirth);

        var totalCount = await usersQuery.CountAsync(ct);

        var users = await usersQuery.Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .ToListAsync(ct);

        return new GetUsersResponse(users, totalCount);
    }
}