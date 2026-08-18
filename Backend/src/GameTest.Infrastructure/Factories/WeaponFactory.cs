using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;

namespace GameTest.Infrastructure.Factories;

public class WeaponFactory : IWeaponFactory
{
    public Weapon Create(
        string name,
        string description,
        WeaponType type,
        IEnumerable<(WeaponStat Stat, IEnumerable<LevelProgression> Levels, IEnumerable<TemporaryLevel> TemporaryLevels)> properties,
        IEnumerable<TemporaryUpgradeLevel> temporaryUpgradeLevels)
    {
        var weaponProperties = properties
            .Select(property => new WeaponProperty(
                property.Stat,
                property.Levels,
                property.TemporaryLevels))
            .ToList();

        return new Weapon(
            name,
            description,
            type,
            weaponProperties,
            temporaryUpgradeLevels);
    }
}
