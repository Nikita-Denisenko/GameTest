namespace Assets.Scripts.ValueObjects
{
    public class PropertyLevel
    {
        public int Level { get; }
        public float Bonus { get; }

        public PropertyLevel(
            int level, 
            float bonus)
        {
            Level = level;
            Bonus = bonus;
        }
    }
}
