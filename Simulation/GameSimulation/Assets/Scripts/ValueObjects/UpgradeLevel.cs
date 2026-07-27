namespace Assets.Scripts.ValueObjects
{
    public class UpgradeLevel
    {
        public int Level { get; private set; }
        public float Value { get; private set; }
        public int Price { get; private set; }

        public UpgradeLevel(
            int level, 
            float value, 
            int price)
        {
            Level = level;
            Value = value;
            Price = price;
        }
    }
}
