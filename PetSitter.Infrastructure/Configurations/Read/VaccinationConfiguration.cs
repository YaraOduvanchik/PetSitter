using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetSitter.Application.DTOs;

namespace PetSitter.Infrastructure.Configurations.Read;

public class VaccinationConfiguration : IEntityTypeConfiguration<VaccinationDto>
{
    public void Configure(EntityTypeBuilder<VaccinationDto> builder)
    {
        builder.ToTable("vaccinations");

        builder.HasKey(v => v.Id);
    }
}