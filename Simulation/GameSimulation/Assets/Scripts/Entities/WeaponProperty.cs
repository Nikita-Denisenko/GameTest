using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;
using Assets.Scripts.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Entities
{
    public class WeaponProperty
    {
        public string Name { get; private set; } = string.Empty;
        public int StatId { get; private set; }
        public WeaponStatType StatType { get; private set; }
        public float StaticValue { get; private set; }
        public float TemporaryBonus { get; private set; }

        private readonly List<PropertyLevel> _temporaryLevels =
            new List<PropertyLevel>();

        public IReadOnlyCollection<PropertyLevel> TemporaryLevels
            => _temporaryLevels;

        public float TotalValue => StaticValue + TemporaryBonus;

        public WeaponProperty(
            string name,
            int statId,
            WeaponStatType statType,
            float staticValue,
            IEnumerable<PropertyLevel> temporaryLevels)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidWeaponStateException(
                    "Weapon property name cannot be empty.");

            if (statId <= 0)
                throw new InvalidWeaponStateException(
                    "Weapon property StatId must be greater than 0.");

            if (staticValue < 0)
                throw new InvalidWeaponStateException(
                    "Weapon property static value cannot be negative.");

            if (temporaryLevels == null || !temporaryLevels.Any())
                throw new InvalidWeaponStateException(
                    "Weapon property must have at least one temporary level.");

            Name = name;
            StatId = statId;
            StatType = statType;
            StaticValue = staticValue;
            TemporaryBonus = 0;
            _temporaryLevels.AddRange(temporaryLevels);
        }

        public void SetBonusAtWeaponLevel(int weaponLevel)
        {
            var level = _temporaryLevels
                .FirstOrDefault(x => x.Level == weaponLevel);

            if (level == null)
            {
                throw new InvalidWeaponStateException(
                    $"Weapon level {weaponLevel} does not exist.");
            }

            TemporaryBonus = level.Bonus;
        }

        public float? GetNextLevelBonus(int weaponLevel)
        {
            var nextWeaponLevel = weaponLevel + 1;

            var nextLevel = _temporaryLevels
                .FirstOrDefault(x => x.Level == nextWeaponLevel);

            return nextLevel?.Bonus;
        }
    }
}
