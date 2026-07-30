namespace Assets.Scripts.ValueObjects
{
    public class UpgradeLevel
    {
        public int Level { get; }
        public int Price { get; }

        public UpgradeLevel(int level, int price) 
        {
            Level = level;
            Price = price;
        }
    }
}
