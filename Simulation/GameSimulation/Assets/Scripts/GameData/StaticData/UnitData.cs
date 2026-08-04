using Assets.Scripts.Enums;
using Assets.Scripts.Exceptions;
using Assets.Scripts.GameData.StaticData;
using System.Collections.Generic;

namespace Assets.Scripts.StaticData
{
    public class UnitData
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public UnitType Type { get; }
        public int StartWeaponId { get; }
        public PassiveAbilityData PassiveAbility { get; }
        public IReadOnlyCollection<UnitPropertyData> Properties { get; }
        public IReadOnlyCollection<TemporaryUpgradeLevelData> TemporaryUpgradeLevels { get; }

        public UnitData(
            int id,
            string name,
            string description,
            UnitType type,
            int startWeaponId,
            PassiveAbilityData passiveAbility,
            IReadOnlyCollection<UnitPropertyData> properties,
            IReadOnlyCollection<TemporaryUpgradeLevelData> temporaryUpgradeLevels)
        {
            if (id <= 0)
                throw new InvalidUnitStateException("Unit id must be greater than zero.");

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidUnitStateException("Unit name cannot be empty.");

            if (startWeaponId <= 0)
                throw new InvalidUnitStateException("Start weapon id must be greater than zero.");

            Id = id;
            Name = name;
            Description = description ?? string.Empty;
            Type = type;
            StartWeaponId = startWeaponId;
            PassiveAbility = passiveAbility ?? throw new InvalidUnitStateException("Passive ability cannot be null.");
            Properties = properties ?? throw new InvalidUnitStateException("Properties cannot be null.");
            TemporaryUpgradeLevels = temporaryUpgradeLevels;
        }
    }
}
