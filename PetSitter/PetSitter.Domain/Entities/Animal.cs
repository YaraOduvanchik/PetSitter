using PetSitter.Domain.ValueObjects;

namespace PetSitter.Domain.Entities;

public class Animal
{
    public const int MAX_NAME_LENGTH = 100;
    public const int MAX_DESCRIPTION_LENGTH = 300;
    
    public Animal(Guid id, string name, string description, Gender gender, int age, Kind kind, string breed, float weight)
    {
        Id = id;
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

    public List<Photo> Photos { get; private set; } = [];

    public List<Vaccination> Vaccinations { get; private set; } = [];

    public List<Disease> Diseases { get; private set; } = [];
}

public enum Gender
{
    Male,
    Female,
}