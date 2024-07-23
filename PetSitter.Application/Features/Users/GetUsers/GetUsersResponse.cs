using PetSitter.Application.DTOs;

namespace PetSitter.Application.Features.Users.GetUsers;

public record GetUsersResponse(IEnumerable<UserDto> Users, int TotalCount);