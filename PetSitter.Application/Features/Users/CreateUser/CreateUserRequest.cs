using FluentValidation;
using PetSitter.Application.CommonValidators;
using PetSitter.Domain.ValueObjects;

namespace PetSitter.Application.Features.Users.CreateUser;

public record CreateUserRequest(
    string Name,
    string Surname,
    string Patronymic,
    string PhoneNumber,
    DateTimeOffset DateOfBirth,
    string City,
    string Street,
    string Building,
    string Index);

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