using Assets.Scripts.Exceptions;

namespace Assets.Scripts.StaticData
{
    public class ItemTemporaryLevelData
    {
        public int Level { get; }
        public float Bonus { get; }
        public int Price { get; }

        public ItemTemporaryLevelData(
            int level,
            float bonus,
            int price)
        {
            if (level <= 0)
                throw new InvalidValueObjectException("Level must be greater than zero.");

            if (bonus < 0)
                throw new InvalidValueObjectException("Bonus cannot be negative.");

            if (price <= 0)
                throw new InvalidValueObjectException("Price must be greater than zero.");

            Level = level;
            Bonus = bonus;
            Price = price;
        }
    }
}
