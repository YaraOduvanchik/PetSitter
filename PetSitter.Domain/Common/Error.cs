using System.Text.Json;

namespace PetSitter.Domain.Common;

public class Error
{
    public string Code { get; }

    public string Message { get; }

    public Error(string code, string message)
    {
        Code = code;

        Message = message;
    }

    public string Serialize()
    {
        return JsonSerializer.Serialize(this);
    }

    public static Error? Deserialize(string serialized)
    {
        return JsonSerializer.Deserialize<Error>(serialized);
    }
}

public static class Errors
{
    public static class General
    {
        public static Error NotFound(Guid? id = null)
        {
            var forId = id == null ? "" : $" for Id '{id}'";
            return new("record.not.found", $"record not found{forId}");
        }

        public static Error ValueIsInvalid(string? name = null)
        {
            var label = name ?? "Value";
            return new("value.is.invalid", $"{label} is invalid");
        }

        public static Error ValueIsRequired(string? name = null)
        {
            var label = name ?? "Value";
            return new("value.is.required", $"{label} is required");
        }

        public static Error InvalidLength(string? name = null)
        {
            var label = name == null ? " " : " " + name + " ";
            return new("length.is.invalid", $"invalid{label}length");
        }

        public static Error SaveFailure(string? name = null)
        {
            var label = name ?? "Value";
            return new("record.save.failure", $"{label} failed to save");
        }
    }
}