using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;
using PetSitter.Domain.Entities;

namespace PetSitter.Application.Features.Diseases.CreateDisease;

public class CreateDiseaseHandler
{
    private readonly IDiseaseRepository _diseaseRepository;

    public CreateDiseaseHandler(IDiseaseRepository diseaseRepository)
    {
        _diseaseRepository = diseaseRepository;
    }

    public async Task<Result<Guid, Error>> Handle(CreateDiseaseRequest request, CancellationToken ct)
    {
        var disease = Disease.Create(
            request.Name,
            request.Symptom);


        var idResult = await _diseaseRepository.Add(disease.Value, ct);

        if (disease.IsFailure)
            return idResult.Error;

        return idResult.Value;
    }
}