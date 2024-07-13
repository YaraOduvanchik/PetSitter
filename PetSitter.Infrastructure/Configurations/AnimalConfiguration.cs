using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetSitter.Domain.Entities;
using PetSitter.Domain.ValueObjects;

namespace PetSitter.Infrastructure.Configurations;

public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(Animal.MAX_NAME_LENGTH);
        
        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(Animal.MAX_DESCRIPTION_LENGTH);
        
        builder.Property(p => p.Gender)
            .IsRequired();

        // builder.ComplexProperty(cp => cp.Gender, b =>
        // {
        //     b.Property(p => p == Gender.Female)
        //         .IsRequired()
        //         .HasColumnName("female");
        //     
        //     b.Property(p => p == Gender.Male)
        //         .IsRequired()
        //         .HasColumnName("male");
        // });
        
        builder.Property(p => p.Age)
            .IsRequired();
        
        builder.ComplexProperty(cp => cp.Kind, b =>
        {
            b.Property(p => p.Type)
                .IsRequired()
                .HasColumnName("kind_type");
        });
        
        builder.Property(p => p.Breed)
            .IsRequired();
        
        builder.Property(p => p.Weight)
            .IsRequired();

        builder.HasMany(p => p.Photos).WithOne();

        builder.HasMany(p => p.Vaccinations).WithOne();
        
        builder.HasMany(p => p.Diseases).WithOne();
    }
}