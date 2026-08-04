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
            IEnumerable<PropertyLevel> temporaryLevels)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidUnitStateException(
                    "Unit property name cannot be empty.");

            if (statId <= 0)
                throw new InvalidUnitStateException(
                    "Unit property StatId must be greater than 0.");

            if (staticValue < 0)
                throw new InvalidUnitStateException(
                    "Unit property static value cannot be negative.");

            if (temporaryLevels == null || !temporaryLevels.Any())
                throw new InvalidUnitStateException(
                    "Unit property must have at least one temporary level.");

            Name = name;
            StatId = statId;
            StatType = statType;
            StaticValue = staticValue;
            TemporaryBonus = 0;
            _temporaryLevels.AddRange(temporaryLevels);
        }

        public void SetBonusAtUnitLevel(int unitLevel)
        {
            var level = _temporaryLevels
                .FirstOrDefault(x => x.Level == unitLevel);

            if (level == null)
            {
                throw new InvalidUnitStateException(
                    $"Unit level {unitLevel} does not exist.");
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
