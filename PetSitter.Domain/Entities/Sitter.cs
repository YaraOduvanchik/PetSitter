using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;
using PetSitter.Domain.ValueObjects;
using Entity = PetSitter.Domain.Common.Entity;

namespace PetSitter.Domain.Entities;

public class Sitter: Entity
{
    private Sitter()
    {
    }

    private Sitter(
        string name,
        string surname,
        string patronymic,
        Address address,
        PhoneNumber phoneNumber,
        DateTimeOffset dateOfBirth,
        int animalCount,
        string preferences)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Address = address;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        AnimalCount = animalCount;
        Preferences = preferences;
    }
    
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Patronymic { get; private set; }
    public int AnimalCount { get; private set; }
    public string Preferences { get; private set; }

    public Address Address { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }

    public DateTimeOffset DateOfBirth { get; private set; }

    public static Result<Sitter, Error> Create(
        string name,
        string surname,
        string patronymic,
        Address address,
        PhoneNumber phoneNumber,
        DateTimeOffset dateOfBirth,
        int animalCount,
        string preferences)
    {
        var nameValue = name.Trim();
        var surnameValue = surname.Trim();
        var patronymicValue = patronymic.Trim();
        var preferencesValue = preferences.Trim();

        if (string.IsNullOrWhiteSpace(nameValue))
            return Errors.General.ValueIsRequired(nameValue);

        if (string.IsNullOrWhiteSpace(surnameValue))
            return Errors.General.ValueIsRequired(surnameValue);

        if (string.IsNullOrWhiteSpace(patronymicValue))
            return Errors.General.ValueIsRequired(patronymicValue);

        if (animalCount <= 0)
            return Errors.General.ValueIsRequired(nameof(animalCount));

        if (string.IsNullOrWhiteSpace(preferencesValue))
            return Errors.General.ValueIsRequired(preferencesValue);

        if (dateOfBirth > DateTimeOffset.Now)
            return Errors.General.ValueIsInvalid($"Sitter: {nameof(dateOfBirth)}");

        return new Sitter(
            nameValue,
            surnameValue,
            patronymicValue,
            address,
            phoneNumber,
            dateOfBirth,
            animalCount,
            preferences
        );
    }
}