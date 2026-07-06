namespace GameTest.Domain.Entities
{
    public class PlayerItem
    {
        public int Id { get; private set; }
        public int PlayerId { get; private set; }
        public Player Player { get; private set; } = null!;
        public int ItemId { get; private set; }
        public Item Item { get; private set; } = null!;
        public double Bonus { get; private set; }
        public int Level { get; private set; }
        public int? NextLevelPrice { get; private set; }

        private PlayerItem() { }

        public PlayerItem(Item item, int level = 1)
        {
            if (level < 1)
                throw new ArgumentOutOfRangeException(nameof(level), "Level must be a positive number");

            ItemId = item.Id;
            Item = item;
            Level = level;
            Bonus = Item.Effect.GetValueAtLevel(level);
            NextLevelPrice = Item.Effect.GetNextLevelPrice(level);
        }

        public void UpLevel()
        {
            if (Level >= Item.MaxLevel)
                throw new InvalidOperationException("You have reached the maximum level for this item.");

            Level++;
            RecalculateBonus();
            RecalculateNextLevelPrice();
        }

        private void RecalculateBonus() => Bonus = Item.Effect.GetValueAtLevel(Level);
        private void RecalculateNextLevelPrice() => NextLevelPrice = Item.Effect.GetNextLevelPrice(Level);
    }
}
