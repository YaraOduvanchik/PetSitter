using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetSitter.Application.DTOs;

namespace PetSitter.Infrastructure.Configurations.Read;

public class AnimalConfiguration : IEntityTypeConfiguration<AnimalDto>
{
    public void Configure(EntityTypeBuilder<AnimalDto> builder)
    {
        builder.ToTable("animals");

        builder.HasKey(a => a.Id);

        // builder.Navigation(a => a.Photos)
        //     .AutoInclude();

        builder.HasMany(a => a.Photos)
            .WithOne()
            .HasForeignKey(ph => ph.AnimalId);

        builder.HasMany(a => a.Vaccinations)
            .WithOne()
            .HasForeignKey(v => v.AnimalId);

        builder.HasMany(a => a.Diseases)
            .WithOne()
            .HasForeignKey(d => d.AnimalId);
    }
}