using Assets.Scripts.Exceptions;

namespace Assets.Scripts.ValueObjects
{
    public class ItemDrop
    {
        public int ItemId { get; }
        public float Chance { get; }

        public ItemDrop(
            int itemId,
            float chance)
        {
            if (itemId <= 0)
                throw new InvalidValueObjectException(
                    "Item ID must be greater than 0.");

            if (chance < 0 || chance > 1)
                throw new InvalidValueObjectException(
                    "Chance must be between 0 and 1.");

            ItemId = itemId;
            Chance = chance;
        }
    }
}
