using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Entities
{
    public class WeaponProperty
    {
        public int Id { get; private set; }
        public int WeaponId { get; private set; }
        public Weapon Weapon { get; private set; } = null!;
        public int StatId { get; private set; }
        public WeaponStat Stat { get; private set; } = null!;

        private readonly List<LevelProgression> _levels = [];
        public IReadOnlyCollection<LevelProgression> Levels => _levels;
        public int MaxLevel => _levels.Count > 0 ? _levels.Max(l => l.Level) : 0;
        public string Name => Stat.Name;
        public WeaponStatType StatType => Stat.Type;

        private WeaponProperty() { }

        public WeaponProperty(
            WeaponStat stat,
            IEnumerable<LevelProgression> levels)
        {
            if (levels == null || !levels.Any())
                throw new ArgumentException("Levels cannot be empty", nameof(levels));

            if (stat == null) 
                throw new ArgumentNullException(nameof(stat));

            StatId = stat.Id;
            Stat = stat;
            _levels.AddRange(levels);
        }

        public double GetValueAtLevel(int level)
        {
            var levelInfo = _levels.FirstOrDefault(l => l.Level == level);
            if (levelInfo == null)
                throw new ArgumentException($"Level {level} does not exist.");
            return levelInfo.Value;
        }

        public int? GetNextLevelPrice(int currentLevel)
        {
            var nextLevel = currentLevel + 1;
            return _levels.FirstOrDefault(l => l.Level == nextLevel)?.Price;
        }

        public double? GetNextLevelValue(int currentLevel)
        {
            var nextLevel = currentLevel + 1;
            return _levels.FirstOrDefault(l => l.Level == nextLevel)?.Value;
        }
    }
}