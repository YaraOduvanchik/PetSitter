using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetSitter.Application.Dtos;

namespace PetSitter.Infrastructure.Configurations.Read;

public class AnimalConfiguration : IEntityTypeConfiguration<AnimalDto>
{
    public void Configure(EntityTypeBuilder<AnimalDto> builder)
    {
        builder.ToTable("animals");

        builder.HasKey(a => a.Id);

        builder.Navigation(a => a.Photos)
            .AutoInclude();

        builder.HasMany(a => a.Photos)
            .WithOne()
            .HasForeignKey(ph => ph.AnimalId);
    }
}