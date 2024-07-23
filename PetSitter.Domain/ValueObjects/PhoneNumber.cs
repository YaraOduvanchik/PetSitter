using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;

namespace PetSitter.Domain.ValueObjects;

public class PhoneNumber
{
    public const string RUSSIAN_PHONE_REGEX = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

    private PhoneNumber(string number)
    {
        Number = number;
    }

    public string Number { get; }

    public static Result<PhoneNumber, Error> Create(string input)
    {
        input = input.Trim();

        if (input.Length < 1)
            return Errors.General.InvalidLength("input");

        if (Regex.IsMatch(input, RUSSIAN_PHONE_REGEX) == false)
            return Errors.General.ValueIsRequired();

        return new PhoneNumber(input);
    }
}