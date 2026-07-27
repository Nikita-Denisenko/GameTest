using Assets.Scripts.Enums;
using Assets.Scripts.ValueObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Enemy
    {
        public int Id { get; private set; }
        public Vector2 Position { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public EnemyType Type { get; private set; }
        public EnemyAttackType AttackType { get; private set; }

        private readonly List<EnemyStaticProperty> _staticProperties =
            new List<EnemyStaticProperty>();

        public IReadOnlyCollection<EnemyStaticProperty> StaticProperties
            => _staticProperties;

        public Enemy(
            int id,
            Vector2 position,
            string name,
            string description,
            EnemyType type,
            EnemyAttackType attackType,
            IEnumerable<EnemyStaticProperty> staticProperties)
        {
            Id = id;
            Position = position;
            Name = name;
            Description = description;
            Type = type;
            AttackType = attackType;

            _staticProperties.AddRange(staticProperties);
        }
    }
}