using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Tests;

public class PlayerUnitTests
{
    private Unit CreateUnit()
    {
        var weaponStat = new WeaponStat(
            "Damage",
            "Weapon damage",
            WeaponStatType.Damage);

        var weaponProperty = new WeaponProperty(
            weaponStat,
            [
                new LevelProgression(1, 10, 100)
            ]);

        var weapon = new Weapon(
            "Sword",
            "Basic sword",
            WeaponType.Sword,
            [
                weaponProperty
            ]);


        var unitStat = new UnitStat(
            "MaxHealth",
            "Maximum health",
            UnitStatType.MaxHealth);

        var unitProperty = new UnitProperty(
            unitStat,
            [
                new LevelProgression(1, 100, 100)
            ]);


        return new Unit(
            "Warrior",
            "Strong warrior",
            UnitType.Warrior,
            weapon,
            "Power",
            "Increase damage",
            5,
            PassiveAbilityType.IncreasedDamage,
            [
                unitProperty
            ]);
    }


    [Fact]
    public void Constructor_ShouldCreatePlayerUnit_WhenUnitValid()
    {
        var unit = CreateUnit();

        var playerUnit = new PlayerUnit(unit);

        Assert.Equal(unit, playerUnit.Unit);
        Assert.Equal(unit.Id, playerUnit.UnitId);
    }


    [Fact]
    public void Constructor_ShouldCopyUnitProperties()
    {
        var unit = CreateUnit();

        var playerUnit = new PlayerUnit(unit);

        Assert.Equal(
            unit.Properties.Count,
            playerUnit.Properties.Count);
    }
}