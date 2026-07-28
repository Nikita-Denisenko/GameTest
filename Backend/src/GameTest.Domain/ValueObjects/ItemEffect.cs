using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;

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


        public ItemEffect(
            string name,
            string description,
            ItemEffectType type,
            IEnumerable<LevelProgression> levels)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name cannot be empty");

            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Description cannot be empty");

            ArgumentNullException.ThrowIfNull(levels);

            var levelList = levels.ToList();

            if (levelList.Count == 0)
                throw new DomainException("Levels cannot be empty");

            if (levelList
                .GroupBy(x => x.Level)
                .Any(x => x.Count() > 1))
            {
                throw new DomainException("Levels cannot contain duplicates");
            }

            Name = name;
            Description = description;
            Type = type;

            _levels.AddRange(levelList);
        }

        public float GetValueAtLevel(int level)
        {
            var itemLevel = _levels.FirstOrDefault(l => l.Level == level);
            if (itemLevel == null)
                throw new DomainException($"Level {level} does not exist for this effect.");
            return itemLevel.Value;
        }

        public int? GetNextLevelPrice(int currentLevel)
        {
            var nextLevel = currentLevel + 1;
            return _levels.FirstOrDefault(l => l.Level == nextLevel)?.Price;
        }

        public float? GetNextLevelBonus(int currentLevel)
        {
            var nextLevel = currentLevel + 1;
            return _levels.FirstOrDefault(l => l.Level == nextLevel)?.Value;
        }
    } 
}