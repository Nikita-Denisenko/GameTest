namespace GameTest.Domain.ValueObjects
{
    public record LevelProgression
    {
        public int Level { get; }
        public double Value { get; }
        public int Price { get; }

        public LevelProgression(int level, double value, int price)
        {
            if (level < 1)
                throw new ArgumentException("Level must be greater than 0");

            if (value < 0)
                throw new ArgumentException("Value cannot be negative");

            if (price < 0)
                throw new ArgumentException("Price cannot be negative");

            Level = level;
            Value = value;
            Price = price;
        }
    }
}
