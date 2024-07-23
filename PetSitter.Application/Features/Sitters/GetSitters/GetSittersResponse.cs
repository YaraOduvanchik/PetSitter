using PetSitter.Application.DTOs;

namespace PetSitter.Application.Features.Sitters.GetSitters;

public record GetSittersResponse(IEnumerable<SitterDto> Sitters, int TotalCount);