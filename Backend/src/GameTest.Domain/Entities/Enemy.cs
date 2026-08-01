using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Entities
{
    public class Enemy
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public EnemyType Type { get; private set; }
        public EnemyAttackType AttackType { get; private set; }
        public EnemyMovementType MovementType { get; private set; }
        public EnemyLoot Loot { get; private set; } = null!;

        private readonly List<EnemyProperty> _properties = [];
        public IReadOnlyCollection<EnemyProperty> Properties => _properties;

        private Enemy() { }

        public Enemy(
            string name, 
            string description, 
            EnemyType type, 
            EnemyAttackType attackType, 
            EnemyMovementType movementType,
            IEnumerable<EnemyProperty> properties,
            EnemyLoot loot)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name cannot be empty");

            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Description cannot be empty");

            if (!Enum.IsDefined(typeof(EnemyType), type))
                throw new DomainException("Invalid enemy type");

            if (!Enum.IsDefined(typeof(EnemyAttackType), attackType))
                throw new DomainException("Invalid enemy attack type");

            if (!Enum.IsDefined(typeof(EnemyMovementType), movementType))
                throw new DomainException("Invalid enemy movement type");

            if (properties == null || !properties.Any())
                throw new DomainException("Properties cannot be empty");

            Name = name;
            Description = description;
            Type = type;
            AttackType = attackType;
            MovementType = movementType;
            _properties.AddRange(properties);
            Loot = loot;
        }
    }
}
