using System.Text.Json;

namespace PetSitter.Domain.Common;

public class Error
{
    public const string Separator = "||";

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }
    public string Message { get; }

    public string Serialize()
    {
        return $"{Code}{Separator}{Message}";
    }

    public static Error? Deserialize(string serialized)
    {
        var data = serialized.Split([Separator], StringSplitOptions.RemoveEmptyEntries);

        if (data.Length < 2)
            throw new($"Invalid error serialization: '{serialized}'");

        return new(data[0], data[1]);
    }
}

public static class Errors
{
    public static class General
    {
        public static Error NotFound(Guid? id = null)
        {
            var forId = id == null ? "" : $" for Id '{id}'";
            return new Error("record.not.found", $"record not found{forId}");
        }

        public static Error ValueIsInvalid(string? name = null)
        {
            var label = name ?? "Value";
            return new Error("value.is.invalid", $"{label} is invalid");
        }

        public static Error ValueIsRequired(string? name = null)
        {
            var label = name ?? "Value";
            return new Error("value.is.required", $"{label} is required");
        }

        public static Error InvalidLength(string? name = null)
        {
            var label = name == null ? " " : " " + name + " ";
            return new Error("length.is.invalid", $"invalid{label}length");
        }

        public static Error SaveFailure(string? name = null)
        {
            var label = name ?? "Value";
            return new Error("record.save.failure", $"{label} failed to save");
        }

        public static Error CantSave(string? name = null)
        {
            var label = name ?? "Value";
            return new Error("record.cant.save", $"{label} can not be save");
        }
    }
}