using FluentValidation;

namespace PetSitter.Application.Features.Animals.GetAnimals;

public record GetAnimalsRequest(
    string? Name,
    string? Description,
    string? TypeKind,
    int Size = 10,
    int Page = 1);

public class GetAnimalsValidator : AbstractValidator<GetAnimalsRequest>
{
    public GetAnimalsValidator()
    {
        RuleFor(x => x.Page).NotNull().GreaterThan(0);
        RuleFor(x => x.Size).NotNull().GreaterThan(0);
    }
}