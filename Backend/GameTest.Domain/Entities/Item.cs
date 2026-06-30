using GameTest.Domain.Enums;

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
            ItemEffectType effectType
        )
        {
            Name = name;
            Description = description;
            Type = type;
            Effect = new ItemEffect(effectName, effectDescription, effectType);
        }
    }
}