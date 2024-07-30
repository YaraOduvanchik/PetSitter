using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using PetSitter.Application.Abstractions;
using PetSitter.Application.Features.Animals;
using PetSitter.Application.Features.Diseases;
using PetSitter.Application.Features.Sitters;
using PetSitter.Application.Features.Users;
using PetSitter.Infrastructure.DbContexts;
using PetSitter.Infrastructure.Options;
using PetSitter.Infrastructure.Queries.Animals;
using PetSitter.Infrastructure.Queries.Sitters;
using PetSitter.Infrastructure.Queries.Users;
using PetSitter.Infrastructure.Repository;
using PetSitter.Infrastructure.Services;

namespace PetSitter.Infrastructure;

public static class DependencyRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddRepositories()
            .AddDataStorages(configuration)
            .AddQueries()
            .AddProviders();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAnimalRepository, AnimalRepository>();
        services.AddScoped<ISitterRepository, SitterRepository>();
        services.AddScoped<IDiseaseRepository, DiseaseRepository>();

        return services;
    }

    private static IServiceCollection AddProviders(this IServiceCollection services)
    {
        services.AddScoped<IMinioProvider, MinioProvider>();

        return services;
    }

    private static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.AddScoped<GetUsersQuery>();
        services.AddScoped<GetAnimalsQuery>();
        services.AddScoped<GetSittersQuery>();

        return services;
    }

    private static IServiceCollection AddDataStorages(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<PetSitterWriteDbContext>();
        services.AddScoped<PetSitterReadDbContext>();

        services.AddMinio(options =>
        {
            var minioOptions = configuration
                                   .GetSection(MinioOptions.Minio)
                                   .Get<MinioOptions>()
                                   ?? throw new("Minio configuration not found");

            options.WithEndpoint(minioOptions.Endpoint);
            options.WithCredentials(minioOptions.AccessKey, minioOptions.SecretKey);
            options.WithSSL(false);
        });

        return services;
    }
}