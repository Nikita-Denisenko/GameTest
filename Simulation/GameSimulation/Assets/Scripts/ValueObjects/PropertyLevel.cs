using Assets.Scripts.Exceptions;

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
            if (level <= 0)
                throw new InvalidValueObjectException(
                    "Level must be greater than 0.");

            if (bonus < 0)
                throw new InvalidValueObjectException(
                    "Bonus cannot be negative.");

            Level = level;
            Bonus = bonus;
        }
    }
}
