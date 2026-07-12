using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Tests;

public class UnitTests
{
    private Weapon CreateWeapon()
    {
        var stat = new WeaponStat(
            "Damage",
            "Weapon damage",
            WeaponStatType.Damage);

        var property = new WeaponProperty(
            stat,
            [
                new LevelProgression(1, 10, 100)
            ]);

        return new Weapon(
            "Sword",
            "Basic sword",
            WeaponType.Sword,
            [
                property
            ]);
    }


    private UnitProperty CreateProperty()
    {
        var stat = new UnitStat(
            "MaxHealth",
            "Maximum health",
            UnitStatType.MaxHealth);

        return new UnitProperty(
            stat,
            [
                new LevelProgression(1, 100, 100),
                new LevelProgression(2, 150, 200)
            ]);
    }


    [Fact]
    public void Constructor_ShouldCreateUnit_WhenDataValid()
    {
        var weapon = CreateWeapon();

        var unit = new Unit(
            "Knight",
            "Strong warrior",
            UnitType.Warrior,
            weapon,
            "Power",
            "Increase damage",
            5,
            PassiveAbilityType.IncreasedDamage,
            [
                CreateProperty()
            ]);

        Assert.Equal("Knight", unit.Name);
        Assert.Equal("Strong warrior", unit.Description);
        Assert.Equal(UnitType.Warrior, unit.Type);
        Assert.Equal(weapon, unit.StartWeapon);
        Assert.Single(unit.Properties);
        Assert.NotNull(unit.PassiveAbility);
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenNameEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Unit(
                "",
                "Description",
                UnitType.Warrior,
                CreateWeapon(),
                "Power",
                "Increase damage",
                5,
                PassiveAbilityType.IncreasedDamage,
                [
                    CreateProperty()
                ]));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenDescriptionEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Unit(
                "Knight",
                "",
                UnitType.Warrior,
                CreateWeapon(),
                "Power",
                "Increase damage",
                5,
                PassiveAbilityType.IncreasedDamage,
                [
                    CreateProperty()
                ]));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenUnitTypeInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new Unit(
                "Knight",
                "Description",
                (UnitType)999,
                CreateWeapon(),
                "Power",
                "Increase damage",
                5,
                PassiveAbilityType.IncreasedDamage,
                [
                    CreateProperty()
                ]));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenPassiveAbilityNameEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Unit(
                "Knight",
                "Description",
                UnitType.Warrior,
                CreateWeapon(),
                "",
                "Increase damage",
                5,
                PassiveAbilityType.IncreasedDamage,
                [
                    CreateProperty()
                ]));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenPassiveAbilityDescriptionEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Unit(
                "Knight",
                "Description",
                UnitType.Warrior,
                CreateWeapon(),
                "Power",
                "",
                5,
                PassiveAbilityType.IncreasedDamage,
                [
                    CreateProperty()
                ]));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenPassiveAbilityBonusNegative()
    {
        Assert.Throws<DomainException>(() =>
            new Unit(
                "Knight",
                "Description",
                UnitType.Warrior,
                CreateWeapon(),
                "Power",
                "Increase damage",
                -1,
                PassiveAbilityType.IncreasedDamage,
                [
                    CreateProperty()
                ]));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenPassiveAbilityTypeInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new Unit(
                "Knight",
                "Description",
                UnitType.Warrior,
                CreateWeapon(),
                "Power",
                "Increase damage",
                5,
                (PassiveAbilityType)999,
                [
                    CreateProperty()
                ]));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenPropertiesEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Unit(
                "Knight",
                "Description",
                UnitType.Warrior,
                CreateWeapon(),
                "Power",
                "Increase damage",
                5,
                PassiveAbilityType.IncreasedDamage,
                []));
    }


    [Fact]
    public void Constructor_ShouldSetStartWeaponId()
    {
        var weapon = CreateWeapon();

        var unit = new Unit(
            "Knight",
            "Strong warrior",
            UnitType.Warrior,
            weapon,
            "Power",
            "Increase damage",
            5,
            PassiveAbilityType.IncreasedDamage,
            [
                CreateProperty()
            ]);

        Assert.Equal(weapon.Id, unit.StartWeaponId);
    }


    [Fact]
    public void Constructor_ShouldSetPassiveAbilityBonus()
    {
        var unit = new Unit(
            "Knight",
            "Strong warrior",
            UnitType.Warrior,
            CreateWeapon(),
            "Power",
            "Increase damage",
            5,
            PassiveAbilityType.IncreasedDamage,
            [
                CreateProperty()
            ]);

        Assert.Equal(5, unit.PassiveAbility.Bonus);
    }
}