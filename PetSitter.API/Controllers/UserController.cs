using Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetSitter.Application;

namespace PetSitter.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _service;
    private readonly IValidator<CreateUserRequest> _validator;

    public UserController(UserService service, IValidator<CreateUserRequest> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken ct)
    {
        var result = await _validator.ValidateAsync(request, ct);

        if(result.IsValid == false)
        {
            return BadRequest(result.Errors);
        }

        var idResult = await _service.CreateUser(request, ct);

        if (idResult.IsFailure)
        {
            return BadRequest(idResult.Error);
        }
        
        return Ok(idResult.Value);
    }
}