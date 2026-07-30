using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;
using Assets.Scripts.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Entities
{
    public class UnitProperty
    {
        public string Name { get; private set; } = string.Empty;
        public int StatId { get; private set; }
        public UnitStatType StatType { get; private set; }
        public float StaticValue { get; private set; }
        public float TemporaryBonus { get; private set; }

        private readonly List<PropertyLevel> _temporaryLevels =
            new List<PropertyLevel>();

        public IReadOnlyCollection<PropertyLevel> TemporaryLevels
            => _temporaryLevels;

        public float TotalValue => StaticValue + TemporaryBonus;

        public UnitProperty(
            string name,
            int statId,
            UnitStatType statType,
            float staticValue,
            float temporaryBonus,
            IEnumerable<PropertyLevel> temporaryLevels)
        {
            Name = name;
            StatId = statId;
            StatType = statType;
            StaticValue = staticValue;
            TemporaryBonus = temporaryBonus;
            _temporaryLevels.AddRange(temporaryLevels);
        }

        public void SetBonusAtUnitLevel(int unitLevel)
        {
            var level = _temporaryLevels
                .FirstOrDefault(x => x.Level == unitLevel);

            if (level == null)
            {
                throw new SimulationException(
                    $"Unit Level {unitLevel} does not exists");
            }

            TemporaryBonus = level.Bonus;
        }

        public float? GetNextLevelBonus(int unitLevel)
        {
            var nextUnitLevel = unitLevel + 1;

            var nextLevel = _temporaryLevels
                .FirstOrDefault(x => x.Level == nextUnitLevel);

            return nextLevel?.Bonus;
        }
    }
}
