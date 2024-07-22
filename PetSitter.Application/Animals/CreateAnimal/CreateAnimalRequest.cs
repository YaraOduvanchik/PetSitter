using FluentValidation;

namespace PetSitter.Application.Animals.CreateAnimal;

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