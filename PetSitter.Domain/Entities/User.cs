using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;
using PetSitter.Domain.ValueObjects;
using Entity = PetSitter.Domain.Common.Entity;

namespace PetSitter.Domain.Entities;

public class User: Entity
{
    private User()
    {
    }

    private User(
        string name,
        string surname,
        string patronymic,
        PhoneNumber phoneNumber,
        DateTimeOffset dateOfBirth,
        Address address)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        Address = address;
    }
    
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Patronymic { get; private set; }

    public DateTimeOffset DateOfBirth { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }
    public Address Address { get; private set; }

    public IReadOnlyList<Animal> Animals => _animals;
    private readonly List<Animal> _animals = [];

    public void PublishAnimal(Animal animal)
    {
        _animals.Add(animal);
    }

    public static Result<User, Error> Create(
        string name,
        string surname,
        string patronymic,
        PhoneNumber phoneNumber,
        DateTimeOffset dateOfBirth,
        Address address)
    {
        var nameValue = name.Trim();
        var surnameValue = surname.Trim();
        var patronymicValue = patronymic.Trim();

        if (string.IsNullOrWhiteSpace(nameValue))
            return Errors.General.ValueIsRequired(nameValue);

        if (string.IsNullOrWhiteSpace(surnameValue))
            return Errors.General.ValueIsRequired(surnameValue);

        if (string.IsNullOrWhiteSpace(patronymicValue))
            return Errors.General.ValueIsRequired(patronymicValue);

        if (dateOfBirth > DateTimeOffset.Now)
            return Errors.General.ValueIsInvalid($"User: {nameof(dateOfBirth)}");

        return new User(
            nameValue,
            surnameValue,
            patronymicValue,
            phoneNumber,
            dateOfBirth,
            address
        );
    }
}