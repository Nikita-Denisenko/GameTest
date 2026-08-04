using GameTest.Domain.Exceptions;

namespace GameTest.Domain.ValueObjects
{
    public record ItemTemporaryLevel
    {
        public int Level { get; init; }
        public float Bonus { get; init; }
        public int Price { get; init; }

        public ItemTemporaryLevel(int level, float bonus, int price)
        {
            if (level < 1)
                throw new DomainException("Level must be greater than 0");

            if (bonus < 0)
                throw new DomainException("Bonus cannot be negative");

            if (price < 0)
                throw new DomainException("Price cannot be negative");

            Level = level;
            Bonus = bonus;
            Price = price;
        }
    }
}
