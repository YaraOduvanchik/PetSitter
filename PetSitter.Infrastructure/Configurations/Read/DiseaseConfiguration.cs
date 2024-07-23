using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetSitter.Application.DTOs;

namespace PetSitter.Infrastructure.Configurations.Read;

public class DiseaseConfiguration : IEntityTypeConfiguration<DiseaseDto>
{
    public void Configure(EntityTypeBuilder<DiseaseDto> builder)
    {
        builder.ToTable("diseases");

        builder.HasKey(d => d.Id);
    }
}