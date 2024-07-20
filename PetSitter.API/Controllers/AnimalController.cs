using Contracts;
using Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using PetSitter.Application;

namespace PetSitter.API.Controllers;

[Route("[controller]")]
public class AnimalController : ApplicationController
{
    private readonly AnimalService _service;

    public AnimalController(AnimalService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAnimalRequest request, CancellationToken ct)
    {
        var idResult = await _service.CreateAnimal(request, ct);

        if (idResult.IsFailure)
        {
            return BadRequest(idResult.Error);
        }

        return Ok(idResult.Value);
    }
}