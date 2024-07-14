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
            .IsRequired();

        builder.Property(a => a.CompletionDate)
            .IsRequired();

        builder.Property(a => a.Description)
            .IsRequired();

        builder.Property(a => a.Price)
            .IsRequired();

        builder.HasOne<Animal>()
            .WithMany()
            .HasForeignKey(a => a.AnimalId)
            .IsRequired();
    }
}