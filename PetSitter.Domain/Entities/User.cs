using PetSitter.Domain.ValueObjects;

namespace PetSitter.Domain.Entities;

public class User
{
    private User()
    {
        
    }
    
    public User(
        Guid id,
        string name,
        string surname,
        string patronymic,
        PhoneNumber phoneNumber,
        DateTimeOffset dateOfBirth,
        Address address)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        Address = address;
    }
    
    public Guid Id { get; private set; }
    
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Patronymic { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }
    public Address Address { get; private set; }
    
    public DateTimeOffset DateOfBirth { get; private set; }
}