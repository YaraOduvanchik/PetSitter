using CSharpFunctionalExtensions;
using PetSitter.Application.Abstractions;
using PetSitter.Application.Features.Animals;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;

namespace PetSitter.Application.Features.Sitters.UploadPhoto;

public class UploadAnimalPhotoHandler
{
    private readonly IMinioProvider _minioProvider;

    private readonly IAnimalRepository _animalRepository;

    public UploadAnimalPhotoHandler(IMinioProvider minioService, IAnimalRepository animalRepository)
    {
        _minioProvider = minioService;

        _animalRepository = animalRepository;
    }

    public async Task<Result<string, Error>> Handle(UploadAnimalPhotoRequest request, CancellationToken ct)
    {
        var animal = await _animalRepository.GetById(request.SitterId, ct);
        if (animal.IsFailure)
            return animal.Error;

        var photoId = Guid.NewGuid();

        var path = await _minioProvider.UploadPhoto(request.File, photoId);
        if (path.IsFailure)
            return path.Error;

        var photo = Photo.CreateAndActivate(photoId, path.Value);
        if (photo.IsFailure)
            return photo.Error;

        var isSuccessUpload = animal.Value.AddPhoto(photo.Value);
        if (isSuccessUpload.IsFailure)
            return isSuccessUpload.Error;

        var result = await _animalRepository.Save(ct);
        if (result.IsFailure)
            return result.Error;

        return path;
    }
}