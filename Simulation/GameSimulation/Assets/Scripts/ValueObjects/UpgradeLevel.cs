using Assets.Scripts.Exceptions;

namespace Assets.Scripts.ValueObjects
{
    public class UpgradeLevel
    {
        public int Level { get; }
        public int Price { get; }

        public UpgradeLevel(
            int level,
            int price)
        {
            if (level <= 0)
                throw new InvalidValueObjectException(
                    "Level must be greater than 0.");

            if (price < 0)
                throw new InvalidValueObjectException(
                    "Price cannot be negative.");

            Level = level;
            Price = price;
        }
    }
}
