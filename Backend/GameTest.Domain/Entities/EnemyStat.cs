

using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;

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
                throw new DomainException("Name cannot be empty");
            
            if (string.IsNullOrWhiteSpace(description)) 
                throw new DomainException("Description cannot be empty");

            if (!Enum.IsDefined(typeof(EnemyStatType), type))
                throw new DomainException("Invalid enemy stat type");

            Name = name;
            Description = description;
            Type = type;
        }
    }
}
