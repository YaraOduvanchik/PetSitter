using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PetSitter.Application.Abstractions;
using PetSitter.Infrastructure.DbContexts;
using PetSitter.Infrastructure.Queries;
using PetSitter.Infrastructure.Queries.Animals;
using PetSitter.Infrastructure.Queries.Users;
using PetSitter.Infrastructure.Repository;

namespace PetSitter.Infrastructure;

public static class DependencyRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddRepositories()
            .AddDatabase()
            .AddQueries();

        return services;
    }
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAnimalsRepository, AnimalRepository>();

        return services;
    }
    
    private static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.AddScoped<GetUsersQuery>();
        services.AddScoped<GetAnimalsQuery>();

        return services;
    }
    
    private static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddScoped<PetSitterWriteDbContext>();
        services.AddScoped<PetSitterReadDbContext>();
        
        return services;
    }
}