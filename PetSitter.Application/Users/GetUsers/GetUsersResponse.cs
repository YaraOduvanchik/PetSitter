using PetSitter.Application.Dtos;

namespace PetSitter.Application.Users.GetUsers;

public record GetUsersResponse(IEnumerable<UserDto> Users, int TotalCount);