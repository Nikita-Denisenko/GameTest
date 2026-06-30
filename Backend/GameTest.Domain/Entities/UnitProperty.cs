using GameTest.Domain.Enums;
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

        private readonly List<UnitPropertyLevel> _levels = [];
        public IReadOnlyCollection<UnitPropertyLevel> Levels => _levels;
        public int MaxLevel => _levels.Count > 0 ? _levels.Max(l => l.Level) : 0;
        public string Name => Stat.Name;
        public UnitStatType StatType => Stat.Type;

        private UnitProperty() { }

        public UnitProperty(
            int unitId,
            int statId,
            IEnumerable<UnitPropertyLevel> levels)
        {
            UnitId = unitId;
            StatId = statId;
            if (levels == null || !levels.Any())
                throw new ArgumentException("Levels cannot be empty", nameof(levels));
            _levels.AddRange(levels);
        }

        public double GetValueAtLevel(int level)
        {
            var levelInfo = _levels.FirstOrDefault(l => l.Level == level);
            if (levelInfo == null)
                throw new ArgumentException($"Level {level} does not exist.");
            return levelInfo.Value;
        }
    }
}
