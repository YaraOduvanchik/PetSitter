using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;
using Entity = PetSitter.Domain.Common.Entity;

namespace PetSitter.Domain.Entities;

public class Animal : Entity
{
    public const int MAX_NAME_LENGTH = 100;

    public const int MAX_DESCRIPTION_LENGTH = 300;

    private const int PHOTO_COUNT_LIMIT = 5;
    
    private Animal()
    {
    }

    private Animal(
        Guid userId,
        string name,
        string description,
        string typeKind,
        string gender,
        DateTimeOffset birthday,
        string breed,
        float weight)

    {
        UserId = userId;
        Name = name;
        Description = description;
        TypeKind = typeKind;
        Gender = gender;
        Birthday = birthday;
        Breed = breed;
        Weight = weight;
    }

    public Guid UserId { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string TypeKind { get; private set; }

    public string Gender { get; private set; }

    public DateTimeOffset Birthday { get; private set; }

    public string Breed { get; private set; }

    public float Weight { get; private set; }

    public IReadOnlyCollection<Photo> Photos => _photos;
    private readonly List<Photo> _photos = [];
    
    public IReadOnlyCollection<Disease> Diseases => _diseases;
    private readonly List<Disease> _diseases = [];
    
    public IReadOnlyCollection<Vaccination> Vaccinations => _vaccinations;
    private readonly List<Vaccination> _vaccinations = [];
   
    
    public Result<bool, Error> AddPhoto(Photo photo)
    {
        _photos.Add(photo);
        
        if (_photos.Count >= PHOTO_COUNT_LIMIT)
            return Errors.Animals.PhotoCountLimit();
        
        return true;
    }
    
    public void AddDisease(Disease disease)
    {
        _diseases.Add(disease);
    }
    
    public void AddVaccination(Vaccination vaccination)
    {
        _vaccinations.Add(vaccination);
    }

    public static Result<Animal, Error> Create(
        Guid userId,
        string name,
        string description,
        string typeKind,
        string gender,
        string breed,
        DateTimeOffset birthday,
        float weight)
    {
        var nameValue = name.Trim();
        var descriptionValue = description.Trim();
        var typeKindValue = typeKind.Trim();
        var genderValue = gender.Trim();
        var breedValue = breed.Trim();

        if (string.IsNullOrWhiteSpace(nameValue))
            return Errors.General.ValueIsRequired();

        if (nameValue.Length > MAX_NAME_LENGTH)
            return Errors.General.InvalidLength();

        if (string.IsNullOrWhiteSpace(descriptionValue))
            return Errors.General.ValueIsRequired();

        if (descriptionValue.Length > MAX_DESCRIPTION_LENGTH)
            return Errors.General.InvalidLength();

        if (string.IsNullOrWhiteSpace(typeKindValue))
            return Errors.General.ValueIsRequired();

        if (string.IsNullOrWhiteSpace(genderValue))
            return Errors.General.ValueIsRequired();

        if (string.IsNullOrWhiteSpace(breedValue))
            return Errors.General.ValueIsRequired();

        if (birthday > DateTimeOffset.Now) return Errors.General.ValueIsInvalid();

        return new Animal(
            userId,
            nameValue,
            descriptionValue,
            typeKindValue,
            gender,
            birthday,
            breedValue,
            weight);
    }
}