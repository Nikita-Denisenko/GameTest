using Assets.Scripts.Exceptions;

namespace Assets.Scripts.StaticData
{
    public class TemporaryLevelData
    {
        public int Level { get; }
        public float Value { get; }
        public int Price { get; }

        public TemporaryLevelData(
            int level,
            float value,
            int price)
        {
            if (level <= 0)
                throw new InvalidValueObjectException("Level must be greater than zero.");

            if (price <= 0)
                throw new InvalidValueObjectException("Price must be greater than zero.");

            Level = level;
            Value = value;
            Price = price;
        }
    }
}
