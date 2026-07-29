namespace Assets.Scripts.ValueObjects
{
    public class UpgradeLevel
    {
        public int Level { get; private set; }
        public int Price { get; private set; }

        public UpgradeLevel(int level, int price) 
        {
            Level = level;
            Price = price;
        }
    }
}
