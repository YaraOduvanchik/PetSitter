using Contracts.Dtos;

namespace Contracts.Responses;

public record GetAllUsersResponse(IEnumerable<UserDto> users);