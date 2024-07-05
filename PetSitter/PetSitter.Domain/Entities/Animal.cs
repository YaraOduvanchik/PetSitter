using PetSitter.Domain.ValueObjects;

namespace PetSitter.Domain.Entities;

public class Animal
{
    public Animal(
        Kind kind, 
        string breed, 
        string name, 
        int age, 
        Gender gender, 
        DateTimeOffset dateOfBirth, 
        string description, 
        float weight, 
        string photo)
    {
        Kind = kind;
        Breed = breed;
        Name = name;
        Age = age;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        Description = description;
        Weight = weight;
        Photo = photo;
    }

    public Guid Id { get; private set; }

    public Kind Kind { get; private set; }

    public string Breed { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    public int Age { get; private set; }

    public Gender Gender { get; private set; }

    public DateTimeOffset DateOfBirth { get; private set; }

    public string Description { get; private set; } = string.Empty;

    //public List<Vaccination> Vaccinations { get; set; } = [];
    
    //public List<Disease> Diseases { get; set; } = [];

    public float Weight { get; private set; }

    public string Photo { get; private set; } = string.Empty;
}

public enum Gender
{
    Male,
    Female,
}