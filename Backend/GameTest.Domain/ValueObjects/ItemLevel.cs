namespace GameTest.Domain.ValueObjects
{
    public record ItemLevel
    {
        public int Level { get; }
        public double Bonus { get; }

        public ItemLevel(int level, double bonus)
        {
            if (level < 1)
                throw new ArgumentException("Level must be greater than 0");

            if (bonus < 0)
                throw new ArgumentException("Bonus cannot be negative");

            Level = level;
            Bonus = bonus;
        }
    }
}
