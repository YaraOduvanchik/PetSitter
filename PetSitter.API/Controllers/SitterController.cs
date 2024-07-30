using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
using PetSitter.Application.Features.Sitters.CreateSitter;
using PetSitter.Application.Features.Sitters.GetSitters;
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
}