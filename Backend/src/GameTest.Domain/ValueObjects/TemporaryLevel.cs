using GameTest.Domain.Exceptions;

namespace GameTest.Domain.ValueObjects
{
    public record TemporaryLevel
    {
        public int Level { get; init; }
        public float Bonus { get; init; }

        public TemporaryLevel(int level, float bonus)
        {
            if (level < 1)
                throw new DomainException("Level must be greater than 0");

            if (bonus < 0)
                throw new DomainException("Bonus cannot be negative");

            Level = level;
            Bonus = bonus;
        }
    }
}
