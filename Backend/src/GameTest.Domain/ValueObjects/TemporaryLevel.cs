using GameTest.Domain.Exceptions;

namespace GameTest.Domain.ValueObjects
{
    public record TemporaryLevel
    {
        public int Level { get; init; }
        public float Value { get; init; }
        public int Price { get; init; }

        public TemporaryLevel(int level, float value, int price)
        {
            if (level < 1)
                throw new DomainException("Level must be greater than 0");

            if (value < 0)
                throw new DomainException("Value cannot be negative");

            if (price < 0)
                throw new DomainException("Price cannot be negative");

            Level = level;
            Value = value;
            Price = price;
        }
    }
}
