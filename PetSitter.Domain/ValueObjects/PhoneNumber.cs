using System.Text.RegularExpressions;

namespace PetSitter.Domain.ValueObjects;

public record PhoneNumber
{
    public const string RUSSIAN_PHONE_REGEX = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

    public string Number { get; }
    
    private PhoneNumber(string number)
    {
        Number = number;
    }

    public PhoneNumber Create(string input)
    {
        input = input.Trim();
        
        if (string.IsNullOrWhiteSpace(input))
            throw new AggregateException();

        if (Regex.IsMatch(input, RUSSIAN_PHONE_REGEX) == false)
            throw new AggregateException();

        return new PhoneNumber(input);
    }
}