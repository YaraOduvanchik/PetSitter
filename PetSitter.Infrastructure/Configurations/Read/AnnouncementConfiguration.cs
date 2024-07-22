namespace PetSitter.Infrastructure.Configurations.Read;

// public class AnnouncementConfiguration : IEntityTypeConfiguration<AnnouncementDto>
// {
//     public void Configure(EntityTypeBuilder<AnnouncementDto> builder)
//     {
//         builder.ToTable("announcements");
//
//         builder.HasKey(a => a.Id);
//
//         builder.HasOne(a => a.UserId)
//             .WithMany()
//             .HasForeignKey(x => x.);
//     }
// }