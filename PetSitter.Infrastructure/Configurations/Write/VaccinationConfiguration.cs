using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetSitter.Domain.Entities;

namespace PetSitter.Infrastructure.Configurations.Write;

public class VaccinationConfiguration : IEntityTypeConfiguration<Vaccination>
{
    public void Configure(EntityTypeBuilder<Vaccination> builder)
    {
        builder.ToTable("vaccinations");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Name)
            .IsRequired();

        builder.Property(v => v.DurationDay)
            .IsRequired();

        builder.Property(v => v.IsTimeLimit)
            .IsRequired();
    }
}