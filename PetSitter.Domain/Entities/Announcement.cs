using CSharpFunctionalExtensions;
using PetSitter.Domain.Common;

namespace PetSitter.Domain.Entities;

public class Announcement
{
    private Announcement()
    {

    }

    private Announcement(
        Guid animalId,
        string receipt,
        DateTimeOffset transferDate,
        DateTimeOffset completionDate,
        string description,
        decimal price)
    {
        AnimalId = animalId;
        Receipt = receipt;
        TransferDate = transferDate;
        CompletionDate = completionDate;
        Description = description;
        Price = price;
    }

    public Guid Id { get; private set; }
    public Guid AnimalId { get; private set; }

    public string Receipt { get; private set; }
    public string Description { get; private set; }

    public DateTimeOffset TransferDate { get; private set; }
    public DateTimeOffset CompletionDate { get; private set; }

    public decimal Price { get; private set; }

    public static Result<Announcement, Error> Create(
        Guid animalId,
        string receipt,
        DateTimeOffset transferDate,
        DateTimeOffset completionDate,
        string description,
        decimal price)
    {
        var receiptValue = receipt.Trim();
        var descriptionValue = description.Trim();

        if (string.IsNullOrWhiteSpace(receiptValue))
            return Errors.General.ValueIsRequired(receiptValue);

        if (string.IsNullOrWhiteSpace(descriptionValue))
            return Errors.General.ValueIsRequired(descriptionValue);

        if (transferDate > DateTimeOffset.Now)
            return Errors.General.ValueIsInvalid(nameof(transferDate));

        if (completionDate > DateTimeOffset.Now)
            return Errors.General.ValueIsInvalid(nameof(completionDate));

        if (price <= 0)
            return Errors.General.ValueIsInvalid(nameof(price));

        return new Announcement(
            animalId,
            receiptValue,
            transferDate,
            completionDate,
            descriptionValue,
            price
        );
    }
}