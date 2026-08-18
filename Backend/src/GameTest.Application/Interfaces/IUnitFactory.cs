using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;

namespace GameTest.Application.Interfaces;

public interface IUnitFactory
{
    Unit Create(
        string name,
        string description,
        UnitType type,
        Weapon startWeapon,
        string passiveAbilityName,
        string passiveAbilityDescription,
        float passiveAbilityBonus,
        PassiveAbilityType passiveAbilityType,
        IEnumerable<(UnitStat Stat, IEnumerable<LevelProgression> Levels, IEnumerable<TemporaryLevel> TemporaryLevels)> properties,
        IEnumerable<TemporaryUpgradeLevel> temporaryUpgradeLevels);
}
