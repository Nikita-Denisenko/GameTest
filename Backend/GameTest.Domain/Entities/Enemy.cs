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
            Name = name;
            Description = description;
            Type = type;
            AttackType = attackType;
            _properties.AddRange(properties);
        }
    }
}
