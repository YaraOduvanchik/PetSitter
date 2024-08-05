using FluentValidation;
using PetSitter.Application.CommonValidators;
using PetSitter.Application.Features.Diseases.CreateDisease;
using PetSitter.Application.Features.Photos.CreatePhoto;
using PetSitter.Application.Features.Vaccinations.CreateVaccination;
using PetSitter.Domain.Common;

namespace PetSitter.Application.Features.Animals.CreateAnimal;

public record CreateAnimalRequest(
    Guid UserId,
    string Name,
    string Description,
    string TypeKind,
    string Gender,
    string Breed,
    DateTimeOffset Birthday,
    float Weight);

public class CreateAnimalRequestValidator : AbstractValidator<CreateAnimalRequest>
{
    public CreateAnimalRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.SHORT_TITLE_LENGTH);

        RuleFor(x => x.Description)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.LONG_TITLE_LENGTH);

        RuleFor(x => x.TypeKind)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.SHORT_TITLE_LENGTH);

        RuleFor(x => x.Gender)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.SHORT_TITLE_LENGTH);

        RuleFor(x => x.Breed)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.SHORT_TITLE_LENGTH);

        RuleFor(x => x.Birthday)
            .LessThanWithError(DateTimeOffset.UtcNow);

        RuleFor(x => x.Weight)
            .NotEmptyWithError();
    }
}