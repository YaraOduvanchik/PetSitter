using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace PetSitter.Application.Validators;

public static class DependencyRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
        services.AddValidatorsFromAssembly(typeof(DependencyRegistration).Assembly);

        return services;
    }
}