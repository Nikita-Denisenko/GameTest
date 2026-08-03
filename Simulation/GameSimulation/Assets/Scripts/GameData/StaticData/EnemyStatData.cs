using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;

namespace Assets.Scripts.StaticData
{
    public class EnemyStatData
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public EnemyStatType Type { get; }

        public EnemyStatData(
            int id,
            string name,
            string description,
            EnemyStatType type)
        {
            if (id <= 0)
                throw new InvalidEnemyStateException("Enemy stat id must be greater than zero.");

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidEnemyStateException("Enemy stat name cannot be empty.");

            Id = id;
            Name = name;
            Description = description ?? string.Empty;
            Type = type;
        }
    }
}
