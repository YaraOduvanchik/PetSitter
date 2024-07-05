namespace PetSitter.Domain.Entities;

public class Announcement
{
    public User User { get; set; }

    public Animal Animal { get; set; }

    public string Receipt { get; set; } = string.Empty;

    public DateTimeOffset TransferDate { get; set; }

    public DateTimeOffset CompletionDate { get; set; }

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }
}