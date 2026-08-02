using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;

namespace Assets.Scripts.ValueObjects
{
    public class EnemyStaticProperty
    {
        public string Name { get; }
        public int StatId { get; }
        public EnemyStatType StatType { get; }
        public float Value { get; }

        public EnemyStaticProperty(
            string name,
            int statId,
            EnemyStatType statType,
            float value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidEnemyStateException(
                    "Enemy property name cannot be empty.");

            if (statId <= 0)
                throw new InvalidEnemyStateException(
                    "Enemy property StatId must be greater than 0.");

            if (value < 0)
                throw new InvalidEnemyStateException(
                    "Enemy property value cannot be negative.");

            Name = name;
            StatId = statId;
            StatType = statType;
            Value = value;
        }
    }
}
