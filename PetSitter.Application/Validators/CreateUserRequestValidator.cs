using Contracts;
using FluentValidation;
using PetSitter.Domain.ValueObjects;

namespace PetSitter.Application.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.PhoneNumber).MustBeValueObject(PhoneNumber.Create);
        RuleFor(x => new {x.City, x.Street, x.Building, x.Index})
            .MustBeValueObject(x => Address.Create(x.City, x.Street, x.Building, x.Index));
    }
}