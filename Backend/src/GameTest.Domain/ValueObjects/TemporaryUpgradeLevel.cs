using GameTest.Domain.Exceptions;

namespace GameTest.Domain.ValueObjects
{
    public record TemporaryUpgradeLevel
    {
        public int Level { get; init; }
        public int Price { get; init; }

        public TemporaryUpgradeLevel(int level, int price)
        {
            if (level < 1)
                throw new DomainException("Level must be greater than 0");

            if (price < 0)
                throw new DomainException("Price cannot be negative");

            Level = level;
            Price = price;
        }
    }
}
