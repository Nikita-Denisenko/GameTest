using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Entities
{
    public class UnitProperty
    {
        public int Id { get; private set; }
        public int UnitId { get; private set; }
        public Unit Unit { get; private set; } = null!;
        public int StatId { get; private set; }
        public UnitStat Stat { get; private set; } = null!;

        private readonly List<LevelProgression> _levels = [];
        public IReadOnlyCollection<LevelProgression> Levels => _levels;

        private readonly List<TemporaryLevel> _temporaryLevels = [];
        public IReadOnlyCollection<TemporaryLevel> TemporaryLevels => _temporaryLevels;
        public int MaxLevel => _levels.Count > 0 ? _levels.Max(l => l.Level) : 0;
        public string Name => Stat.Name;
        public UnitStatType StatType => Stat.Type;

        private UnitProperty() { }

        public UnitProperty(
            UnitStat stat,
            IEnumerable<LevelProgression> levels,
            IEnumerable<TemporaryLevel> temporaryLevels)
        {
            if (levels == null || !levels.Any())
                throw new DomainException("Levels cannot be empty");

            if (temporaryLevels == null || !temporaryLevels.Any())
                throw new DomainException("Temporary levels cannot be empty");

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
