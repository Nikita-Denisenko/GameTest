using GameTest.Domain.Enums;

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
                throw new ArgumentException("Name cannot be empty", nameof(name));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty", nameof(description));

            if (!Enum.IsDefined(typeof(EnemyType), type))
                throw new ArgumentException("Invalid enemy type", nameof(type));

            if (!Enum.IsDefined(typeof(EnemyAttackType), attackType))
                throw new ArgumentException("Invalid enemy attack type", nameof(attackType));

            if (properties == null || !properties.Any())
                throw new ArgumentException("Properties cannot be empty", nameof(properties));

            Name = name;
            Description = description;
            Type = type;
            AttackType = attackType;
            _properties.AddRange(properties);
        }
    }
}
