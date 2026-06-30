using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Entities
{
    public class ItemEffect
    {
        public int Id { get; private set; }
        public int ItemId { get; private set; }
        public Item Item { get; private set; } = null!;
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public ItemEffectType Type { get; private set; }

        private readonly List<ItemLevel> _levels = [];
        public IReadOnlyCollection<ItemLevel> Levels => _levels;

        private ItemEffect() { }

        public ItemEffect(string name, string description, ItemEffectType type)
        {
            Name = name;
            Description = description;
            Type = type;
        }

        public double GetBonusAtLevel(int level)
        {
            var itemLevel = _levels.FirstOrDefault(l => l.Level == level);
            if (itemLevel == null)
                throw new ArgumentException($"Level {level} does not exist for this effect.");
            return itemLevel.Bonus;
        }
    } 
}
