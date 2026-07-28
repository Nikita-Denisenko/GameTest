using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
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
        
        private readonly List<TemporaryLevel> _temporaryLevels = [];
        public IReadOnlyCollection<TemporaryLevel> TemporaryLevels => _temporaryLevels;

        public int MaxLevel => _levels.Count > 0 ? _levels.Max(l => l.Level) : 0;
        public string Name => Stat.Name;
        public WeaponStatType StatType => Stat.Type;

        private WeaponProperty() { }

        public WeaponProperty(
            WeaponStat stat,
            IEnumerable<LevelProgression> levels,
            IEnumerable<TemporaryLevel> temporaryLevels)
        {
            if (levels == null || !levels.Any())
                throw new DomainException("Levels cannot be empty");

            if (temporaryLevels == null || !temporaryLevels.Any())
                throw new DomainException("Temporary levels cannot be empty");

            if (stat == null) 
                throw new DomainException("Weapon stat cannot be null");

            StatId = stat.Id;
            Stat = stat;
            _levels.AddRange(levels);
            _temporaryLevels.AddRange(temporaryLevels);
        }

        public float GetValueAtLevel(int level)
        {
            var levelInfo = _levels.FirstOrDefault(l => l.Level == level);
            if (levelInfo == null)
                throw new DomainException($"Level {level} does not exist.");
            return levelInfo.Value;
        }

        public int? GetNextLevelPrice(int currentLevel)
        {
            var nextLevel = currentLevel + 1;
            return _levels.FirstOrDefault(l => l.Level == nextLevel)?.Price;
        }

        public float? GetNextLevelValue(int currentLevel)
        {
            var nextLevel = currentLevel + 1;
            return _levels.FirstOrDefault(l => l.Level == nextLevel)?.Value;
        }
    }
}