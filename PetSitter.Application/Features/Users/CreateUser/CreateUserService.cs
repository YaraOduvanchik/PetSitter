using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;
using PetSitter.Domain.ValueObjects;

namespace PetSitter.Application.Features.Users.CreateUser;

public class CreateUserService
{
    private readonly IUserRepository _userRepository;

    public CreateUserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<Guid, Error>> Handle(CreateUserRequest request, CancellationToken ct)
    {
        var address = Address.Create(
            request.City,
            request.Street,
            request.Building,
            request.Index).Value;

        var phoneNumber = PhoneNumber.Create(request.PhoneNumber).Value;

        var user = User.Create(
            request.Name,
            request.Surname,
            request.Patronymic,
            phoneNumber,
            request.DateOfBirth,
            address);

        var idResult = await _userRepository.Add(user.Value, ct);

        if (user.IsFailure)
            return idResult.Error;

        return idResult.Value;
    }
}