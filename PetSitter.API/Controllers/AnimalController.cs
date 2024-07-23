using Microsoft.AspNetCore.Mvc;
using PetSitter.Application.Features.Animals.CreateAnimal;
using PetSitter.Application.Features.Animals.GetAnimals;
using PetSitter.Application.Features.Diseases.CreateDisease;
using PetSitter.Domain.Entities;
using PetSitter.Infrastructure.Queries.Animals;

namespace PetSitter.API.Controllers;

[Route("[controller]")]
public class AnimalController : ApplicationController
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateAnimalService service,
        [FromBody] CreateAnimalRequest request,
        CancellationToken ct)
    {
        var idResult = await service.Handle(request, ct);

        if (idResult.IsFailure)
            return BadRequest(idResult.Error);

        return Ok(idResult.Value);
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromServices] GetAnimalsQuery query,
        [FromQuery] GetAnimalsRequest request,
        CancellationToken ct)
    {
        var response = await query.Handle(request, ct);

        return Ok(response);
    }
    
    // [HttpPost("disease")]
    // public async Task<IActionResult> Create(
    //     [FromServices] CreateDiseaseService service,
    //     [FromBody] CreateDiseaseRequest request,
    //     CancellationToken ct)
    // {
    //     var idResult = await service.Handle(request, ct);
    //
    //     if (idResult.IsFailure)
    //         return BadRequest(idResult.Error);
    //
    //     return Ok(idResult.Value);
    // }
}