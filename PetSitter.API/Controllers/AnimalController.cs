using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetSitter.API.Contracts;
using PetSitter.Infrastructure;

namespace PetSitter.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase
{
    private readonly PetSitterDbContext _context;

    public AnimalController(PetSitterDbContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateAnimalRequest request, CancellationToken ct)
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var animals = await _context.Animals.ToListAsync();
        
        return Ok();
    }
}