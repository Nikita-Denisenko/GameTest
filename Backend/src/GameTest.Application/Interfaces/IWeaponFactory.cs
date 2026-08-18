using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;

namespace GameTest.Application.Interfaces;

public interface IWeaponFactory
{
    Weapon Create(
        string name,
        string description,
        WeaponType type,
        IEnumerable<(WeaponStat Stat, IEnumerable<LevelProgression> Levels, IEnumerable<TemporaryLevel> TemporaryLevels)> properties,
        IEnumerable<TemporaryUpgradeLevel> temporaryUpgradeLevels);
}
