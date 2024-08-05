using CSharpFunctionalExtensions;
using PetSitter.Application.Abstractions;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;

namespace PetSitter.Application.Features.Animals.UploadPhoto;

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
        var animal = await _animalRepository.GetById(request.AnimalId, ct);
        if (animal.IsFailure)
            return animal.Error;

        var newGuid = Guid.NewGuid();

        var path = newGuid.ToString() + Path.GetExtension(request.File.FileName);

        var photo = Photo.CreateAndActivate(path);
        if (photo.IsFailure)
            return photo.Error;

        var isSuccessUpload = animal.Value.AddPhoto(photo.Value);
        if (isSuccessUpload.IsFailure)
            return isSuccessUpload.Error;

        var objectName = await _minioProvider.UploadPhoto(request.File, path);
        if (objectName.IsFailure)
            return objectName.Error;
        
        var result = await _animalRepository.Save(ct);
        if (result.IsFailure)
            return result.Error;

        return path;
    }
}