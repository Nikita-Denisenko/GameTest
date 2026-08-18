using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;

namespace GameTest.Infrastructure.Factories;

public class UnitFactory : IUnitFactory
{
    public Unit Create(
        string name,
        string description,
        UnitType type,
        Weapon startWeapon,
        string passiveAbilityName,
        string passiveAbilityDescription,
        float passiveAbilityBonus,
        PassiveAbilityType passiveAbilityType,
        IEnumerable<(UnitStat Stat, IEnumerable<LevelProgression> Levels, IEnumerable<TemporaryLevel> TemporaryLevels)> properties,
        IEnumerable<TemporaryUpgradeLevel> temporaryUpgradeLevels)
    {
        var unitProperties = properties
            .Select(property => new UnitProperty(
                property.Stat,
                property.Levels,
                property.TemporaryLevels))
            .ToList();

        return new Unit(
            name,
            description,
            type,
            startWeapon,
            passiveAbilityName,
            passiveAbilityDescription,
            passiveAbilityBonus,
            passiveAbilityType,
            unitProperties,
            temporaryUpgradeLevels);
    }
}
