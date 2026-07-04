using GameTest.Domain.Enums;

namespace GameTest.Domain.ValueObjects
{
    public record ItemEffect
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public ItemEffectType Type { get; private set; }

        private readonly List<ItemLevel> _levels = [];
        public IReadOnlyCollection<ItemLevel> Levels => _levels;

        private ItemEffect() { }


        public ItemEffect(string name, string description, ItemEffectType type, IEnumerable<ItemLevel> levels)
        {
            Name = name;
            Description = description;
            Type = type;
            _levels.AddRange(levels);
        }

        public double GetBonusAtLevel(int level)
        {
            var itemLevel = _levels.FirstOrDefault(l => l.Level == level);
            if (itemLevel == null)
                throw new ArgumentException($"Level {level} does not exist for this effect.");
            return itemLevel.Bonus;
        }

        public int? GetNextLevelPrice(int currentLevel)
        {
            var nextLevel = currentLevel + 1;
            return _levels.FirstOrDefault(l => l.Level == nextLevel)?.Price;
        }
    } 
}