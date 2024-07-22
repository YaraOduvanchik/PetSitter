using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PetSitter.Application.Animals.CreateAnimal;
using PetSitter.Application.Users.CreateUser;

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

        return services;
    }
}