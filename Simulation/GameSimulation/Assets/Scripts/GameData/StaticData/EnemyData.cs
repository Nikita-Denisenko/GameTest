using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;
using System.Collections.Generic;

namespace Assets.Scripts.StaticData
{
    public class EnemyData
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public EnemyType EnemyType { get; }
        public EnemyAttackType AttackType { get; }
        public IReadOnlyCollection<EnemyPropertyData> Properties { get; }
        public EnemyMovementType MovementType { get; }
        public EnemyLootData Loot { get; }

        public EnemyData(
            int id,
            string name,
            string description,
            EnemyType enemyType,
            EnemyAttackType attackType,
            IReadOnlyCollection<EnemyPropertyData> properties,
            EnemyMovementType movementType,
            EnemyLootData loot)
        {
            if (id <= 0)
                throw new InvalidEnemyStateException("Enemy id must be greater than zero.");

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidEnemyStateException("Enemy name cannot be empty.");

            Id = id;
            Name = name;
            Description = description ?? string.Empty;
            EnemyType = enemyType;
            AttackType = attackType;
            Properties = properties ?? throw new InvalidEnemyStateException("Enemy properties cannot be null.");
            MovementType = movementType;
            Loot = loot ?? throw new InvalidEnemyStateException("Enemy loot cannot be null.");
        }
    }
}
