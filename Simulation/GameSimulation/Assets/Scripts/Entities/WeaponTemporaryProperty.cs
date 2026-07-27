using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.ValueObjects
{
    public class WeaponTemporaryProperty
    {
        public string Name { get; private set; } = string.Empty;
        public int StatId { get; private set; }
        public WeaponTemporaryStatType Type { get; private set; }
        public float Value { get; private set; }
        public int Level { get; private set; }
        public int? NextLevelPrice { get; private set; }
        public float? NextLevelValue { get; private set; }

        private readonly List<UpgradeLevel> _levels =
            new List<UpgradeLevel>();

        public IReadOnlyCollection<UpgradeLevel> Levels
            => _levels;

        public WeaponTemporaryProperty(
            string name,
            int statId,
            WeaponTemporaryStatType type,
            IEnumerable<UpgradeLevel> levels,
            int level = 1)
        {
            Name = name;
            StatId = statId;
            Type = type;

            _levels.AddRange(levels);

            Level = level;

            RecalculateValue();
            RecalculateNextLevelValue();
            RecalculateNextLevelPrice();
        }

        public void Upgrade()
        {
            if (!HasNextLevel())
            {
                throw new SimulationException(
                    $"You already have maximum level for property {Name}");
            }

            Level++;

            RecalculateValue();
            RecalculateNextLevelValue();
            RecalculateNextLevelPrice();
        }

        public float GetValueAtLevel(int level)
        {
            var upgradeLevel = _levels
                .FirstOrDefault(x => x.Level == level);

            if (upgradeLevel == null)
            {
                throw new SimulationException(
                    $"Level {level} does not exist for property {Name}");
            }

            return upgradeLevel.Value;
        }

        private bool HasNextLevel()
        {
            return _levels.Any(x => x.Level == Level + 1);
        }

        private float GetNextLevelValue()
        {
            var nextLevel = _levels
                .FirstOrDefault(x => x.Level == Level + 1);

            return nextLevel != null
                ? nextLevel.Value
                : 0;
        }

        private int GetNextLevelPrice()
        {
            var nextLevel = _levels
                .FirstOrDefault(x => x.Level == Level + 1);

            return nextLevel != null
                ? nextLevel.Price
                : 0;
        }

        private void RecalculateValue()
        {
            Value = GetValueAtLevel(Level);
        }

        private void RecalculateNextLevelValue()
        {
            NextLevelValue = HasNextLevel()
                ? GetNextLevelValue()
                : (float?)null;
        }

        private void RecalculateNextLevelPrice()
        {
            NextLevelPrice = HasNextLevel()
                ? GetNextLevelPrice()
                : (int?)null;
        }
    }
}