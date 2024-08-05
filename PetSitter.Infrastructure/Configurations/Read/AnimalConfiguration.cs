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
            .IsRequired();

        builder.HasMany(a => a.Vaccinations)
            .WithOne()
            .IsRequired();

        builder.HasMany(a => a.Diseases)
            .WithOne()
            .IsRequired();
    }
}