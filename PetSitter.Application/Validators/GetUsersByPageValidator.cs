using Contracts.Requests;
using FluentValidation;

namespace PetSitter.Application.Validators;

public class GetUsersByPageValidator : AbstractValidator<GetUsersByPageRequest>
{
    public GetUsersByPageValidator()
    {
        RuleFor(x => x.Page).NotNull().GreaterThan(0);
        RuleFor(x => x.Size).NotNull().GreaterThan(0);
    }
}