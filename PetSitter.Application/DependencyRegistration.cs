using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PetSitter.Application.Features.Animals.CreateAnimal;
using PetSitter.Application.Features.Sitters.CreateSitter;
using PetSitter.Application.Features.Users.CreateUser;

namespace PetSitter.Application;

public static class DependencyRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddServices();
        services.AddValidatorsFromAssembly(typeof(DependencyRegistration).Assembly);

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<CreateUserService>();
        services.AddScoped<CreateAnimalService>();
        services.AddScoped<CreateSitterService>();

        return services;
    }
}