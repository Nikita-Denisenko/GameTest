using Assets.Scripts.Exceptions;

namespace Assets.Scripts.ValueObjects
{
    public class ItemUpgradeLevel
    {
        public int Level { get; }
        public float Bonus { get; }
        public int Price { get; }

        public ItemUpgradeLevel(
            int level,
            float bonus,
            int price)
        {
            if (level <= 0)
                throw new InvalidValueObjectException(
                    "Item upgrade level must be greater than 0.");

            if (bonus < 0)
                throw new InvalidValueObjectException(
                    "Item upgrade bonus cannot be negative.");

            if (price < 0)
                throw new InvalidValueObjectException(
                    "Item upgrade price cannot be negative.");

            Level = level;
            Bonus = bonus;
            Price = price;
        }
    }
}
