using Microsoft.AspNetCore.Http;

namespace PetSitter.Application.Features.Animals.UploadPhoto;

public record UploadAnimalPhotoRequest(Guid AnimalId, IFormFile File);