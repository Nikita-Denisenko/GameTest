namespace GameTest.Domain.ValueObjects
{
    public record WeaponPropertyLevel
    {
        public int Level { get; }
        public double Value { get; }

        public WeaponPropertyLevel(int level, double value)
        {
            if (level < 1)
                throw new ArgumentException("Level must be greater than 0");

            if (value < 0)
                throw new ArgumentException("Value cannot be negative");

            Level = level;
            Value = value;
        }
    }
}