using FluentValidation;

namespace PetSitter.Application.Features.Users.GetUsers;

public record GetUsersRequest(
    string? Name,
    string? Surname,
    string? Patronymic,
    int Size = 10,
    int Page = 1);

public class GetUsersValidator : AbstractValidator<GetUsersRequest>
{
    public GetUsersValidator()
    {
        RuleFor(x => x.Page).NotNull().GreaterThan(0);
        RuleFor(x => x.Size).NotNull().GreaterThan(0);
    }
}