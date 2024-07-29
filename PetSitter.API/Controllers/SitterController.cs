using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
using PetSitter.Application.Features.Sitters.CreateSitter;
using PetSitter.Application.Features.Sitters.GetSitters;
using PetSitter.Application.Features.Sitters.UploadPhoto;
using PetSitter.Infrastructure.Queries.Sitters;

namespace PetSitter.API.Controllers;

[Route("[controller]")]
public class SitterController : ApplicationController
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateSitterHandler service,
        [FromBody] CreatedSitterRequest request,
        CancellationToken ct)
    {
        var idResult = await service.Handle(request, ct);

        if (idResult.IsFailure)
            return BadRequest(idResult.Error);

        return Ok(idResult.Value);
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromServices] GetSittersQuery query,
        [FromQuery] GetSittersRequest request,
        CancellationToken ct)
    {
        var response = await query.Handle(request, ct);

        return Ok(response);
    }

    //[HttpGet]
    //public async Task<IActionResult> AddPhoto(
    //    [FromForm] UploadAnimalPhotoRequest request)
    //{
        

    //}

    [HttpGet]
    public async Task<IActionResult> GetPhoto(
        string photo,
        [FromServices] IMinioClient client)
    {
        var presignedGetObjectAsync = new PresignedGetObjectArgs()
            .WithBucket("images")
            .WithObject(photo)
            .WithExpiry(604800);

        var url = await client.PresignedGetObjectAsync(presignedGetObjectAsync);

        return Ok(url);
    }
}