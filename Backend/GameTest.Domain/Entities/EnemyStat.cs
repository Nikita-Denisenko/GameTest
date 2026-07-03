

using GameTest.Domain.Enums;

namespace GameTest.Domain.Entities
{
    public class EnemyStat
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public EnemyStatType Type { get; private set; }

        private EnemyStat() { }

        public EnemyStat(string name, string description, EnemyStatType type)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));
            
            if (string.IsNullOrWhiteSpace(description)) 
                throw new ArgumentException("Description cannot be empty", nameof(description));

            if (!Enum.IsDefined(typeof(EnemyStatType), type))
                throw new ArgumentException("Invalid enemy stat type", nameof(type));

            Name = name;
            Description = description;
            Type = type;
        }
    }
}
