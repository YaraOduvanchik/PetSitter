using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetSitter.Domain.Entities;

namespace PetSitter.Infrastructure.Configurations.Write;

public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.ToTable("animals");

        builder.HasKey(a => a.Id);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(a => a.UserId);

        builder.Property(a => a.Name)
            .IsRequired();

        builder.Property(a => a.Description)
            .IsRequired();

        builder.Property(a => a.TypeKind)
            .IsRequired();

        builder.Property(a => a.Gender)
            .IsRequired();

        builder.Property(a => a.Birthday)
            .IsRequired();

        builder.Property(a => a.Breed)
            .IsRequired();

        builder.Property(a => a.Weight)
            .IsRequired();

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