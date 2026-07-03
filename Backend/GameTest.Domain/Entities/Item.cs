using GameTest.Domain.Enums;
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

        private Item() { }

        public Item
        (
            string name, 
            string description, 
            ItemType type, 
            string effectName,
            string effectDescription,
            ItemEffectType effectType,
            IEnumerable<ItemLevel> levels
        )
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));

            if (string.IsNullOrWhiteSpace(description)) 
                throw new ArgumentException("Description cannot be empty", nameof(description));

            if (!Enum.IsDefined(typeof(ItemType), type)) 
                throw new ArgumentException("Invalid item type", nameof(type));

            if (string.IsNullOrWhiteSpace(effectName))
                throw new ArgumentException("Effect name cannot be empty", nameof(effectName));

            if (string.IsNullOrWhiteSpace(effectDescription))
                throw new ArgumentException("Effect description cannot be empty", nameof(effectDescription));

            if (!Enum.IsDefined(typeof(ItemEffectType), effectType))
                throw new ArgumentException("Invalid item effect type", nameof(effectType));

            if (levels == null || !levels.Any())
                throw new ArgumentException("Levels cannot be null or empty", nameof(levels));

            Name = name;
            Description = description;
            Type = type;
            Effect = new ItemEffect(effectName, effectDescription, effectType, levels);
        }
    }
}