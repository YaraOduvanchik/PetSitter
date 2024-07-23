using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;

namespace PetSitter.Domain.Entities;

public class Photo
{
    private Photo()
    {
    }

    private Photo(string path, bool isMain)
    {
        Path = path;
        IsMain = isMain;
    }

    public Guid Id { get; }

    public string Path { get; private set; }

    public bool IsMain { get; private set; }

    public static Result<Photo, Error> Create(string path, bool isMain)
    {
        var pathValue = path.Trim();

        if (string.IsNullOrWhiteSpace(pathValue))
            return Errors.General.ValueIsRequired(pathValue);

        return new Photo(pathValue, isMain);
    }
}