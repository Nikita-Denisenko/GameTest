using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Entities
{
    public class PlayerItem
    {
        public int Id { get; private set; }
        public int PlayerId { get; private set; }
        public Player Player { get; private set; } = null!;
        public int ItemId { get; private set; }
        public Item Item { get; private set; } = null!;
        public float Bonus { get; private set; }
        public int Level { get; private set; }
        public int? NextLevelPrice { get; private set; }
        public float? NextLevelBonus { get; private set; }

        private PlayerItem() { }

        public PlayerItem(Item item, int level = 1)
        {
            if (level < 1)
                throw new DomainException("Level must be a positive number");

            ItemId = item.Id;
            Item = item;
            Level = level;
            Bonus = Item.Effect.GetValueAtLevel(level);
            NextLevelPrice = Item.Effect.GetNextLevelPrice(level);
            NextLevelBonus = Item.Effect.GetNextLevelBonus(level);
        }

        public void UpLevel()
        {
            if (Level >= Item.MaxLevel)
                throw new DomainException("You have reached the maximum level for this item.");

            Level++;
            RecalculateBonus();
            RecalculateNextLevelPrice();
            RecalculateNextLevelBonus();
        }

        private void RecalculateBonus() => Bonus = Item.Effect.GetValueAtLevel(Level);
        private void RecalculateNextLevelPrice() => NextLevelPrice = Item.Effect.GetNextLevelPrice(Level);
        private void RecalculateNextLevelBonus() => NextLevelBonus = Item.Effect.GetNextLevelBonus(Level);

        public bool CanUpgrade => NextLevelPrice.HasValue;
    }
}
