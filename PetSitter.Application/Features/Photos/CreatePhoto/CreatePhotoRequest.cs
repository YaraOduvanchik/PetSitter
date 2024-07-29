using FluentValidation;

namespace PetSitter.Application.Features.Photos.CreatePhoto;

public record CreatePhotoRequest(
    Guid Id,
    string Path,
    bool IsMain);

public class CreatePhotoRequestValidator : AbstractValidator<CreatePhotoRequest>
{
    public CreatePhotoRequestValidator()
    {
        RuleFor(x => x.Path)
            .NotEmpty();

        RuleFor(x => x.IsMain)
            .NotEmpty();
    }
}