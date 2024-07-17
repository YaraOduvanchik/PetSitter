using Contracts;
using Microsoft.AspNetCore.Mvc;
using PetSitter.Application;

namespace PetSitter.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
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
        {
            return BadRequest(idResult.Error);
        }
        
        return Ok(idResult.Value);
    }
}