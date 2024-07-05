using PetSitter.Domain.Entities;
using PetSitter.Domain.ValueObjects;

namespace PetSitter.API.Controllers;

public partial class PostController
{
    public record CreateAnimalRequest(
        Kind Kind,
        string Breed,
        string Name,
        int Age,
        Gender Gender,
        DateTimeOffset DateOfBirth,
        string Description,
        float Weight,
        string Photo);
}