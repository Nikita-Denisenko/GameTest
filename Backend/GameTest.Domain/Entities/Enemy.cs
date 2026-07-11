using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Entities
{
    public class Enemy
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public EnemyType Type { get; private set; }
        public EnemyAttackType AttackType { get; private set; }
        
        private readonly List<EnemyProperty> _properties = [];
        public IReadOnlyCollection<EnemyProperty> Properties => _properties;

        private Enemy() { }

        public Enemy(
            string name, 
            string description, 
            EnemyType type, 
            EnemyAttackType attackType, 
            IEnumerable<EnemyProperty> properties)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name cannot be empty");

            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Description cannot be empty");

            if (!Enum.IsDefined(typeof(EnemyType), type))
                throw new DomainException("Invalid enemy type");

            if (!Enum.IsDefined(typeof(EnemyAttackType), attackType))
                throw new DomainException("Invalid enemy attack type");

            if (properties == null || !properties.Any())
                throw new DomainException("Properties cannot be empty");

            Name = name;
            Description = description;
            Type = type;
            AttackType = attackType;
            _properties.AddRange(properties);
        }
    }
}
