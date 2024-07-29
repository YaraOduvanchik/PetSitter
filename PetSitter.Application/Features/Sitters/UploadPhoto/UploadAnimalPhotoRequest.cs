using Microsoft.AspNetCore.Http;

namespace PetSitter.Application.Features.Sitters.UploadPhoto;

public record UploadAnimalPhotoRequest(Guid SitterId, IFormFile File);