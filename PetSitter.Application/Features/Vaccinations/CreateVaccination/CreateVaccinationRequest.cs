using FluentValidation;

namespace PetSitter.Application.Features.Vaccinations.CreateVaccination;

public record CreateVaccinationRequest(
    string Name,
    int DurationDay,
    bool IsTimeLimit);

public class CreateVaccinationRequestValidator : AbstractValidator<CreateVaccinationRequest>
{
    public CreateVaccinationRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.DurationDay)
            .NotEmpty();

        RuleFor(x => x.IsTimeLimit)
            .NotEmpty();
    }
}