using Assets.Scripts.Exceptions;

namespace Assets.Scripts.GameData.StaticData
{
    public class TemporaryUpgradeLevelData
    {
        public int Level { get; }
        public int Price { get;}

        public TemporaryUpgradeLevelData(
            int level,
            int price)
        {
            if (level <= 0)
                throw new InvalidValueObjectException("Level must be greater than zero.");

            if (price <= 0)
                throw new InvalidValueObjectException("Price must be greater than zero.");

            Level = level;
            Price = price;
        }
    }
}
