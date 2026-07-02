

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
            Name = name;
            Description = description;
            Type = type;
        }
    }
}
