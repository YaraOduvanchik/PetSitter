using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetSitter.Domain.Entities;

namespace PetSitter.Infrastructure.Configurations;

public class SitterConfiguration : IEntityTypeConfiguration<Sitter>
{
    public void Configure(EntityTypeBuilder<Sitter> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired();
        
        builder.Property(s => s.Surname)
            .IsRequired();
        
        builder.Property(s => s.Patronymic)
            .IsRequired();

        builder.ComplexProperty(s => s.Address, b =>
        {
            b.Property(a => a.City)
                .IsRequired()
                .HasColumnName("city");
            
            b.Property(a => a.Building)
                .IsRequired()
                .HasColumnName("building");
            
            b.Property(a => a.Street)
                .IsRequired()
                .HasColumnName("street");
            
            b.Property(a => a.Index)
                .IsRequired()
                .HasColumnName("index");
        });
        
        builder.ComplexProperty(s => s.PhoneNumber, b =>
        {
            b.Property(a => a.Number)
                .IsRequired()
                .HasColumnName("phone_number");
        });
        
        builder.Property(s => s.DateOfBirth)
            .IsRequired();
        
        builder.Property(s => s.AnimalCount)
            .IsRequired();
        
        builder.Property(s => s.Preferences)
            .IsRequired();
    }
}