using Contracts.Dtos;
using PetSitter.Domain.Entities;

namespace PetSitter.Application.Mapping;

public static class MappingExtensions
{
    public static UserDto ToDto(this User user)
    {
        return new(
            user.Name,
            user.Surname,
            user.Patronymic,
            user.PhoneNumber.Number,
            user.DateOfBirth,
            user.Address.City,
            user.Address.Street,
            user.Address.Building,
            user.Address.Index);
    }
}