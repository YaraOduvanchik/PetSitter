using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace PetSitter.Application.Validators;

public static class DependecyRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<UserService>();

        services.AddValidatorsFromAssembly(typeof(DependecyRegistration).Assembly);

        return services;
    }
}