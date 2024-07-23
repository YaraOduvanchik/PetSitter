using FluentValidation;

namespace PetSitter.Application.Features.Sitters.GetSitters;

public record GetSittersRequest(
    string? Name,
    string? Surname,
    string? Patronymic,
    int Size = 10,
    int Page = 1);

public class GetSitersValidator : AbstractValidator<GetSittersRequest>
{
    public GetSitersValidator()
    {
        RuleFor(x => x.Page).NotNull().GreaterThan(0);
        RuleFor(x => x.Size).NotNull().GreaterThan(0);
    }
}