using FluentValidation;

namespace PetSitter.Application.Features.Sitters.CreateSitter;

public record CreatedSitterRequest(
    string Name,
    string Surname,
    string Patronymic,
    int AnimalCount,
    string Preferences,
    string City,
    string Street,
    string Building,
    string Index,
    string PhoneNumber,
    DateTimeOffset DateOfBirth
);

public class CreateSitterRequestValidator : AbstractValidator<CreatedSitterRequest>
{
    public CreateSitterRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Surname)
            .NotEmpty();

        RuleFor(x => x.Patronymic)
            .NotEmpty();

        RuleFor(x => x.AnimalCount)
            .NotEmpty();

        RuleFor(x => x.Preferences)
            .NotEmpty();

        RuleFor(x => x.City)
            .NotEmpty();

        RuleFor(x => x.Street)
            .NotEmpty();

        RuleFor(x => x.Building)
            .NotEmpty();

        RuleFor(x => x.Index)
            .NotEmpty();

        RuleFor(x => x.PhoneNumber)
            .NotEmpty();

        RuleFor(x => x.DateOfBirth)
            .NotEmpty();
    }
}