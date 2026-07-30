using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Entities
{
    public class Item
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public ItemType Type { get; private set; }
        public ItemEffect Effect { get; private set; } = null!;
        public int MaxLevel => Effect.Levels.Count > 0 ? Effect.Levels.Max(l => l.Level) : 0;

        private readonly List<TemporaryLevel> _temporaryLevels = [];
        public IReadOnlyCollection<TemporaryLevel> TemporaryLevels => _temporaryLevels;

        private Item() { }

        public Item
        (
            string name, 
            string description, 
            ItemType type, 
            string effectName,
            string effectDescription,
            ItemEffectType effectType,
            IEnumerable<LevelProgression> levels,
            IEnumerable<TemporaryLevel> temporaryLevels
        )
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name cannot be empty");

            if (string.IsNullOrWhiteSpace(description)) 
                throw new DomainException("Description cannot be empty");

            if (!Enum.IsDefined(typeof(ItemType), type)) 
                throw new DomainException("Invalid item type");

            if (string.IsNullOrWhiteSpace(effectName))
                throw new DomainException("Effect name cannot be empty");

            if (string.IsNullOrWhiteSpace(effectDescription))
                throw new DomainException("Effect description cannot be empty");

            if (!Enum.IsDefined(typeof(ItemEffectType), effectType))
                throw new DomainException("Invalid item effect type");

            if (levels == null || !levels.Any())
                throw new DomainException("Levels cannot be null or empty");

            if (temporaryLevels == null || !temporaryLevels.Any())
                throw new DomainException("Temporary Levels cannot be empty");

            Name = name;
            Description = description;
            Type = type;
            Effect = new ItemEffect(effectName, effectDescription, effectType, levels);
            _temporaryLevels.AddRange(temporaryLevels);
        }
    }
}