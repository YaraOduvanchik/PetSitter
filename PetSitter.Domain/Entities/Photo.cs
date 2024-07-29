using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;

namespace PetSitter.Domain.Entities;

public class Photo
{
    private Photo()
    {
    }

    private Photo(Guid id, string path, bool isMain)
    {
        Id = id;
        Path = path;
        IsMain = isMain;
    }

    public Guid Id { get; }

    public string Path { get; private set; }

    public bool IsMain { get; private set; }

    public static Result<Photo, Error> CreateAndActivate(Guid id, string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Errors.General.ValueIsRequired(path);

        return new Photo(id, path, true);
    }
}