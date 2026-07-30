namespace Assets.Scripts.ValueObjects
{
    public class ItemUpgradeLevel
    {
        public int Level { get; }
        public float Bonus { get; }
        public int Price { get; }

        public ItemUpgradeLevel(int level, float bonus, int price)
        {
            Level = level;
            Bonus = bonus;
            Price = price;
        }
    }
}
