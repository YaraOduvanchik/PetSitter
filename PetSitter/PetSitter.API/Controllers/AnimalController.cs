using Microsoft.AspNetCore.Mvc;
using PetSitter.API.Contracts;
using PetSitter.Domain.Entities;

namespace PetSitter.API.Controllers;

[ApiController]
[Route("[controller]")]
public partial class AnimalController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateAnimalRequest request, CancellationToken ct)
    {
        // var post = new Animal(
        //     request.Id,
        //     request.Name,
        //     request.Description,
        //     request.Gender,
        //     request.Age,
        //     request.Kind,
        //     request.Breed,
        //     request.Weight);
        return Ok();
    }
}