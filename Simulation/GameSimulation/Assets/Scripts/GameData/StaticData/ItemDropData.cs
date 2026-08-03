using Assets.Scripts.Exceptions;

namespace Assets.Scripts.StaticData
{
    public class ItemDropData
    {
        public int ItemId { get; }
        public float Chance { get; }

        public ItemDropData(
            int itemId,
            float chance)
        {
            if (itemId <= 0)
                throw new InvalidValueObjectException("Item id must be greater than zero.");

            if (chance < 0f || chance > 1f)
                throw new InvalidValueObjectException("Chance must be in range [0; 1].");

            ItemId = itemId;
            Chance = chance;
        }
    }
}
