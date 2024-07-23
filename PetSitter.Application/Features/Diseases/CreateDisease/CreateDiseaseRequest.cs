using FluentValidation;

namespace PetSitter.Application.Features.Diseases.CreateDisease;

public record CreateDiseaseRequest(
    string Name,
    string Symptom);

public class CreateDiseaseRequestValidator : AbstractValidator<CreateDiseaseRequest>
{
    public CreateDiseaseRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Symptom)
            .NotEmpty();
    }
}