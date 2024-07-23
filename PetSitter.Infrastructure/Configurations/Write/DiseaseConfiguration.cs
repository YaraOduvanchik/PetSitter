using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetSitter.Domain.Entities;

namespace PetSitter.Infrastructure.Configurations.Write;

public class DiseaseConfiguration : IEntityTypeConfiguration<Disease>
{
    public void Configure(EntityTypeBuilder<Disease> builder)
    {
        builder.ToTable("diseases");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired();

        builder.Property(d => d.Symptom)
            .IsRequired();
    }
}