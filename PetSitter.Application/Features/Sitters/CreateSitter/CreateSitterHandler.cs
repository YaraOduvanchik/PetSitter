using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;
using PetSitter.Domain.ValueObjects;

namespace PetSitter.Application.Features.Sitters.CreateSitter;

public class CreateSitterHandler
{
    private readonly ISitterRepository _sitterRepository;

    public CreateSitterHandler(ISitterRepository sitterRepository)
    {
        _sitterRepository = sitterRepository;
    }

    public async Task<Result<Guid, Error>> Handle(CreatedSitterRequest request, CancellationToken ct)
    {
        var address = Address.Create(
            request.City,
            request.Street,
            request.Building,
            request.Index).Value;

        var phoneNumber = PhoneNumber.Create(request.PhoneNumber).Value;

        var sitter = Sitter.Create(
            request.Name,
            request.Surname,
            request.Patronymic,
            address,
            phoneNumber,
            request.DateOfBirth,
            request.AnimalCount,
            request.Preferences);

        var idResult = await _sitterRepository.Add(sitter.Value, ct);

        if (sitter.IsFailure)
            return idResult.Error;

        return idResult.Value;
    }
}