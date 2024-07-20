using Contracts;
using Contracts.Requests;
using FluentValidation;
using PetSitter.Domain.ValueObjects;

namespace PetSitter.Application.Validators.User;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        
        RuleFor(x => x.Surname)
            .NotEmpty();
        
        RuleFor(x => x.Patronymic)
            .NotEmpty();
        
        RuleFor(x => x.DateOfBirth)
            .NotEmpty();

        RuleFor(x => x.PhoneNumber)
            .MustBeValueObject(PhoneNumber.Create);
        
        RuleFor(x => new { x.City, x.Street, x.Building, x.Index })
            .MustBeValueObject(x => Address.Create(x.City, x.Street, x.Building, x.Index));
    }
}