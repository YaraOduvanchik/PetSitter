using FluentValidation;

namespace PetSitter.Application.Animals.GetAnimals;

public record GetAnimalsRequest(
    string? Name,
    string? Gender,
    string? Breed,
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