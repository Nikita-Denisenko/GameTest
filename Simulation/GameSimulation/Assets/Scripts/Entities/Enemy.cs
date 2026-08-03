using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;
using Assets.Scripts.Interfaces;
using Assets.Scripts.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Enemy : Unit
    {
        public EnemyType Type { get; private set; }
        public EnemyAttackType AttackType { get; private set; }

        private readonly List<EnemyStaticProperty> _staticProperties =
            new List<EnemyStaticProperty>();

        public IReadOnlyCollection<EnemyStaticProperty> StaticProperties
            => _staticProperties;

        public EnemyLoot Loot { get; private set; }
        public EnemyMovementType MovementType { get; private set; }
        public IMovementStrategy MovementStrategy { get; }

        public Enemy(
            int id,
            Vector2 position,
            string name,
            EnemyType type,
            EnemyAttackType attackType,
            IReadOnlyCollection<EnemyStaticProperty> staticProperties,
            EnemyLoot loot,
            EnemyMovementType movementType,
            IMovementStrategy movementStrategy) 
            : base(id, name, position, GetMaxHealth(staticProperties))
        {
            if (staticProperties == null || !staticProperties.Any())
                throw new InvalidEnemyStateException(
                    $"Enemy with ID {id} must have at least one static property");

            if (loot == null)
                throw new InvalidEnemyStateException(
                    $"Enemy loot cannot be null.");

            if (movementStrategy == null)
            {
                throw new InvalidEnemyStateException(
                    "Enemy movement strategy cannot be null.");
            }

            Type = type;
            AttackType = attackType;
            _staticProperties.AddRange(staticProperties);
            Loot = loot;
            MovementType = movementType;
            MovementStrategy = movementStrategy;
        }

        public float GetPropertyValue(EnemyStatType statType)
        {
            var property = _staticProperties
                .FirstOrDefault(x => x.StatType == statType);
            if (property == null)
                throw new InvalidEnemyStateException(
                    $"Enemy with ID {Id} does not have static property with StatType {statType}");

            return property.Value;
        }

        private static float GetMaxHealth(IEnumerable<EnemyStaticProperty> properties)
        {
            var property = properties
                .FirstOrDefault(p => p.StatType == EnemyStatType.MaxHealth);

            if (property == null)
                throw new InvalidEnemyStateException(
                    "Enemy must have MaxHealth property");

            return property.Value;
        }

        protected override float GetMaxHealth()
        {
            return GetPropertyValue(EnemyStatType.MaxHealth);
        }
    }
}
