using GameTest.Domain.Enums;

namespace GameTest.Domain.ValueObjects
{
    public record ItemEffect
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public ItemEffectType Type { get; private set; }

        private readonly List<LevelProgression> _levels = [];
        public IReadOnlyCollection<LevelProgression> Levels => _levels;

        private ItemEffect() { }


        public ItemEffect(string name, string description, ItemEffectType type, IEnumerable<LevelProgression> levels)
        {
            Name = name;
            Description = description;
            Type = type;
            _levels.AddRange(levels);
        }

        public double GetValueAtLevel(int level)
        {
            var itemLevel = _levels.FirstOrDefault(l => l.Level == level);
            if (itemLevel == null)
                throw new ArgumentException($"Level {level} does not exist for this effect.");
            return itemLevel.Value;
        }

        public int? GetNextLevelPrice(int currentLevel)
        {
            var nextLevel = currentLevel + 1;
            return _levels.FirstOrDefault(l => l.Level == nextLevel)?.Price;
        }

        public double? GetNextLevelBonus(int currentLevel)
        {
            var nextLevel = currentLevel + 1;
            return _levels.FirstOrDefault(l => l.Level == nextLevel)?.Value;
        }
    } 
}