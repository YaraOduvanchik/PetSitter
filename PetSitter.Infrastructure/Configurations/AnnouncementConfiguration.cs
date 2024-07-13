using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetSitter.Domain.Entities;

namespace PetSitter.Infrastructure.Configurations;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Receipt)
            .IsRequired();

        builder.Property(a => a.TransferDate)
            .HasDefaultValue(DateTimeOffset.Now)
            .IsRequired();
        
        builder.Property(a => a.CompletionDate)
            .HasDefaultValue(DateTimeOffset.Now)
            .IsRequired();

        builder.Property(a => a.Description)
            .IsRequired();

        builder.HasOne(a => a.User).WithMany();
        
        builder.HasOne(a => a.Animal).WithMany();
    }
}