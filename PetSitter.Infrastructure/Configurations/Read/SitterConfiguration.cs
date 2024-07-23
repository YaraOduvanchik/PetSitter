using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetSitter.Application.DTOs;

namespace PetSitter.Infrastructure.Configurations.Read;

public class SitterConfiguration : IEntityTypeConfiguration<SitterDto>
{
    public void Configure(EntityTypeBuilder<SitterDto> builder)
    {
        builder.ToTable("sitters");

        builder.HasKey(s => s.Id);
    }
}