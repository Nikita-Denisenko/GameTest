using Assets.Scripts.Exceptions;

namespace Assets.Scripts.GameData.StaticData
{
    public class TemporaryLevelData
    {
        public int Level { get; }
        public float Bonus { get; }


        public TemporaryLevelData(
            int level,
            float bonus)
        {
            if (level <= 0)
                throw new InvalidValueObjectException(
                    "Level must be greater than zero.");

            if (bonus < 0)
                throw new InvalidValueObjectException(
                    "Bonus cannot be negative.");

            Level = level;
            Bonus = bonus;
        }
    }
}