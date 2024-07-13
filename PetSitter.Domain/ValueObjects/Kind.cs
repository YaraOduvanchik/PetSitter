namespace PetSitter.Domain.ValueObjects
{
    public record Kind
    {
        public Kind(string type)
        {
            Type = type;
        }

        public string Type { get; private set; }
    }
}