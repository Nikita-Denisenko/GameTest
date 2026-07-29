namespace Assets.Scripts.ValueObjects
{
    public class PropertyLevel
    {
        public int Level { get; private set; }
        public float Bonus { get; private set; }

        public PropertyLevel(
            int level, 
            float bonus)
        {
            Level = level;
            Bonus = bonus;
        }
    }
}
