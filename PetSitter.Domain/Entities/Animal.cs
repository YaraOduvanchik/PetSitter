using PetSitter.Domain.ValueObjects;

namespace PetSitter.Domain.Entities;

public class Animal
{
    public const int MAX_NAME_LENGTH = 100;
    public const int MAX_DESCRIPTION_LENGTH = 300;

    private Animal()
    {
        
    }
    
    public Animal(
        string name,
        string description,
        Gender gender,
        int age,
        Kind kind,
        string breed,
        float weight)
    {
        Name = name;
        Description = description;
        Gender = gender;
        Age = age;
        Kind = kind;
        Breed = breed;
        Weight = weight;
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }
    
    public string Description { get; private set; }
    
    public Gender Gender { get; private set; }
    
    public int Age { get; private set; }
    
    public Kind Kind { get; private set; }

    public string Breed { get; private set; }

    public float Weight { get; private set; }

    public IReadOnlyCollection<Photo> Photos => _photos;
    private List<Photo> _photos = [];

    public IReadOnlyCollection<Vaccination> Vaccinations => _vaccinations;
    private List<Vaccination> _vaccinations = [];

    public IReadOnlyCollection<Disease> Diseases => _diseases;
    private List<Disease> _diseases = [];
}

public enum Gender
{
    Male,
    Female,
}