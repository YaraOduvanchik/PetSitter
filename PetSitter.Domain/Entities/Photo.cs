using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;
using Entity = PetSitter.Domain.Common.Entity;

namespace PetSitter.Domain.Entities;

public class Photo : Entity
{
    private Photo()
    {
    }

    private Photo(string path, bool isMain)
    {
        Path = path;
        IsMain = isMain;
    }

    public string Path { get; private set; }
    public bool IsMain { get; private set; }

    public static Result<Photo, Error> CreateAndActivate(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Errors.General.ValueIsRequired(path);

        return new Photo(path, true);
    }
}