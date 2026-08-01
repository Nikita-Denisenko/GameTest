using GameTest.Domain.Exceptions;

namespace GameTest.Domain.ValueObjects
{
    public record ItemDrop
    {
        public int ItemId { get; init; }
        public float Chance { get; init; }

        private ItemDrop()
        {
        }

        public ItemDrop(int itemId, float chance)
        {
            if (itemId <= 0) 
                throw new DomainException("ItemId must be greater than 0.");

            if (chance <= 0)
                throw new DomainException("Chance must be greater than 0.");

            ItemId = itemId;
            Chance = chance;
        }
    }
}
