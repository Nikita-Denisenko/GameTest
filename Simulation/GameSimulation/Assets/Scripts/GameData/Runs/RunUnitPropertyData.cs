using Assets.Scripts.Exceptions;

namespace Assets.Scripts.GameData.Runs
{
    public class RunUnitPropertyData
    {
        public int StatId { get; }

        public int Level { get; }

        public float Value { get; }


        public RunUnitPropertyData(
            int statId,
            int level,
            float value)
        {
            if (statId <= 0)
                throw new InvalidValueObjectException(
                    "Stat id must be greater than zero.");

            if (level <= 0)
                throw new InvalidValueObjectException(
                    "Level must be greater than zero.");

            if (value < 0)
                throw new InvalidValueObjectException(
                    "Value cannot be negative.");

            StatId = statId;
            Level = level;
            Value = value;
        }
    }
}

