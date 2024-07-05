using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetSitter.Domain.Entities;
using System.Reflection;
using System.Xml.Linq;

namespace PetSitter.API.Controllers;

[ApiController]
[Route("[controller]")]
public partial class PostController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateAnimalRequest request, CancellationToken ct)
    {
        var post = new Animal(
        request.Kind,
        request.Breed,
        request.Name,
        request.Age,
        request.Gender,
        request.DateOfBirth,
        request.Description,
        request.Weight,
        request.Photo);
        return Ok();
    }
}