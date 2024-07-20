namespace Contracts.Dtos;

public record UserDto(
    string Name,
    string Surname,
    string Patronymic,
    string PhoneNumber,
    DateTimeOffset DateOfBirth,
    string City,
    string Street,
    string Building,
    string Index);