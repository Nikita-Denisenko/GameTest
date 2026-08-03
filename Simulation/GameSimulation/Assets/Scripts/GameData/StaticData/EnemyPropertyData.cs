using Assets.Scripts.Exceptions;

namespace Assets.Scripts.StaticData
{
    public class EnemyPropertyData
    {
        public int StatId { get; }
        public string StatName { get; }
        public float Value { get; }

        public EnemyPropertyData(
            int statId,
            string statName,
            float value)
        {
            if (statId <= 0)
                throw new InvalidEnemyStateException("Stat id must be greater than zero.");

            if (string.IsNullOrWhiteSpace(statName))
                throw new InvalidEnemyStateException("Stat name cannot be empty.");

            StatId = statId;
            StatName = statName;
            Value = value;
        }
    }
}