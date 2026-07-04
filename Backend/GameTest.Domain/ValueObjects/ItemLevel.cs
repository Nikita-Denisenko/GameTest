namespace GameTest.Domain.ValueObjects
{
    public record ItemLevel
    {
        public int Level { get; }
        public double Bonus { get; }
        public int Price { get; }

        public ItemLevel(int level, double bonus, int price)
        {
            if (level < 1)
                throw new ArgumentException("Level must be greater than 0");

            if (price < 0)
                throw new ArgumentException("Price cannot be negative");

            if (bonus < 0)
                throw new ArgumentException("Bonus cannot be negative");

            Level = level;
            Bonus = bonus;
            Price = price;
        }
    }
}
