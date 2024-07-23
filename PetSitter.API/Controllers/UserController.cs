using Microsoft.AspNetCore.Mvc;
using PetSitter.Application.Features.Users.CreateUser;
using PetSitter.Application.Features.Users.GetUsers;
using PetSitter.Infrastructure.Queries.Users;

namespace PetSitter.API.Controllers;

[Route("[controller]")]
public class UserController : ApplicationController
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateUserService service,
        [FromBody] CreateUserRequest request,
        CancellationToken ct)
    {
        var idResult = await service.Handle(request, ct);

        if (idResult.IsFailure)
            return BadRequest(idResult.Error);

        return Ok(idResult.Value);
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromServices] GetUsersQuery query,
        [FromQuery] GetUsersRequest request,
        CancellationToken ct)
    {
        var response = await query.Handle(request, ct);

        return Ok(response);
    }
}