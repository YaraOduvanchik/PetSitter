using FluentValidation;

namespace PetSitter.Application.Features.Diseases.GetDiseases;

public record GetDiseasesRequest(
    string? Name,
    string? Symptoms,
    int Size = 10,
    int Page = 1);

public class GetDiseasesValidator : AbstractValidator<GetDiseasesRequest>
{
    public GetDiseasesValidator()
    {
        RuleFor(x => x.Page).NotNull().GreaterThan(0);
        RuleFor(x => x.Size).NotNull().GreaterThan(0);
    }
}