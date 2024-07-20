namespace Contracts.Requests;

public record GetUsersByPageRequest(int Size = 10, int Page = 1);