using FluentValidation;
using PetSitter.Application.Features.Diseases.CreateDisease;
using PetSitter.Application.Features.Photos.CreatePhoto;
using PetSitter.Application.Features.Vaccinations.CreateVaccination;

namespace PetSitter.Application.Features.Animals.CreateAnimal;

public record CreateAnimalRequest(
    Guid UserId,
    string Name,
    string Description,
    string TypeKind,
    string Gender,
    string Breed,
    DateTimeOffset Birthday,
    float Weight,
    List<CreatePhotoRequest> Photos,
    List<CreateDiseaseRequest> Diseases,
    List<CreateVaccinationRequest> Vaccinations);

public class CreateAnimalRequestValidator : AbstractValidator<CreateAnimalRequest>
{
    public CreateAnimalRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Description)
            .NotEmpty();

        RuleFor(x => x.TypeKind)
            .NotEmpty();

        RuleFor(x => x.Gender)
            .NotEmpty();

        RuleFor(x => x.Breed)
            .NotEmpty();
    }
}