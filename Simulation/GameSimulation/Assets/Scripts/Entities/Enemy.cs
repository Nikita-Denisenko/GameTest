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

        public IMovementStrategy MovementStrategy { get; }

        public Enemy(
            int id,
            Vector2 position,
            string name,
            EnemyType type,
            EnemyAttackType attackType,
            IReadOnlyCollection<EnemyStaticProperty> staticProperties,
            IMovementStrategy movementStrategy) 
            : base(id, name, position, GetMaxHealth(staticProperties))
        {
            Type = type;
            AttackType = attackType;
            _staticProperties.AddRange(staticProperties);
            MovementStrategy = movementStrategy;
        }

        public float GetPropertyValue(EnemyStatType statType)
        {
            var property = _staticProperties
                .FirstOrDefault(x => x.StatType == statType);
            if (property == null)
            {
                throw new SimulationException(
                    $"Enemy with ID {Id} does not have static property with StatType {statType}");
            }
            return property.Value;
        }

        private static float GetMaxHealth(IEnumerable<EnemyStaticProperty> properties)
        {
            var property = properties
                .FirstOrDefault(p => p.StatType == EnemyStatType.MaxHealth);

            if (property == null)
                throw new SimulationException(
                    "Enemy must have MaxHealth property");

            return property.Value;
        }

        protected override float GetMaxHealth()
        {
            return GetPropertyValue(EnemyStatType.MaxHealth);
        }
    }
}
