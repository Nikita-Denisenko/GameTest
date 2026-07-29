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

        public void SetBonusAtWeaponLevel(int weaponLevel)
        {
            var level = _temporaryLevels
                .FirstOrDefault(x => x.Level == weaponLevel);

            if (level == null)
            {
                throw new SimulationException(
                    $"Weapon Level {weaponLevel} does not exists");
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
