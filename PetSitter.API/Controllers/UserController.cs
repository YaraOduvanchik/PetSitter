using Contracts;
using Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using PetSitter.Application;

namespace PetSitter.API.Controllers;

[Route("[controller]")]
public class UserController : ApplicationController
{
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;

    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken ct)
    {
        var idResult = await _service.CreateUser(request, ct);

        if (idResult.IsFailure)
            return BadRequest(idResult.Error);

        return Ok(idResult.Value);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetUsersByPageRequest request , CancellationToken ct)
    {
        var users = await _service.GetUsersByPage(request.Page, request.Size, ct);

        return Ok(users);
    }
}