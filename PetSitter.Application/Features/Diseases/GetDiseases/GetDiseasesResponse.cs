using PetSitter.Application.DTOs;

namespace PetSitter.Application.Features.Diseases.GetDiseases;

public record GetDiseasesResponse(IEnumerable<DiseaseDto> Diseases, int TotalCount);