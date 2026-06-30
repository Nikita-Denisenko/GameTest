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

        private PlayerItem() { }

        public PlayerItem(int playerId, Item item, int level = 1)
        {
            PlayerId = playerId;
            ItemId = item.Id;
            Item = item;
            Level = level;
            Bonus = Item.Effect.GetBonusAtLevel(level);
        }

        public void UpLevel()
        {
            if (Level >= Item.MaxLevel)
                throw new InvalidOperationException("You have reached the maximum level for this item.");

            Level++;
            RecalculateBonus();
        }

        private void RecalculateBonus()
        {
            Bonus = Item.Effect.GetBonusAtLevel(Level);
        }
    }
}
