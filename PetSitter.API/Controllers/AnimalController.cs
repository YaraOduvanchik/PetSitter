using Microsoft.AspNetCore.Mvc;
using PetSitter.Application.Features.Animals.CreateAnimal;
using PetSitter.Application.Features.Animals.GetAnimals;
using PetSitter.Application.Features.Animals.UploadPhoto;
using PetSitter.Infrastructure.Queries.Animals;

namespace PetSitter.API.Controllers;

[Route("[controller]")]
public class AnimalController : ApplicationController
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateAnimalHandler service,
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
    
    [HttpPost("photo")]
    public async Task<IActionResult> UploadPhoto(
        [FromServices] UploadAnimalPhotoHandler handler,
        [FromForm] UploadAnimalPhotoRequest request,
        CancellationToken ct)
    {
        var result = await handler.Handle(request, ct);

        if(result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
    
    // [HttpGet("photo")]
    // public async Task<IActionResult> GetPhoto(
    //     string photo,
    //     [FromServices] IMinioClient client)
    // {
    //     var presignedGetObjectAsync = new PresignedGetObjectArgs()
    //         .WithBucket("images")
    //         .WithObject(photo)
    //         .WithExpiry(604800);
    //
    //     var url = await client.PresignedGetObjectAsync(presignedGetObjectAsync);
    //
    //     return Ok(url);
    // }

    // [HttpPost("disease")]
    // public async Task<IActionResult> Create(
    //     [FromServices] CreateDiseaseHandler service,
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