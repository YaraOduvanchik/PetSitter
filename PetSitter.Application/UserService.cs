using Contracts;
using Contracts.Requests;
using Contracts.Responses;
using CSharpFunctionalExtensions;
using PetSitter.Application.Abstractions;
using PetSitter.Application.Mapping;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;
using PetSitter.Domain.ValueObjects;

namespace PetSitter.Application;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<Guid, Error>> CreateUser(CreateUserRequest request, CancellationToken ct)
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

    public async Task<GetAllUsersResponse> GetUsersByPage(int page, int size, CancellationToken ct)
    {
        var users = await _userRepository.Get(ct);

        var userDtos = users
            .Skip((page-1) * size)
            .Take(size)
            .Select(u => u.ToDto());

        return new(userDtos);
    }
}