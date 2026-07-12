using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Tests;

public class WeaponTests
{
    private WeaponProperty CreateProperty()
    {
        var stat = new WeaponStat(
            "Damage",
            "Damage bonus",
            WeaponStatType.Damage);

        return new WeaponProperty(
            stat,
            [
                new LevelProgression(1, 10, 100)
            ]);
    }


    [Fact]
    public void Constructor_ShouldCreateWeapon_WhenDataValid()
    {
        var weapon = new Weapon(
            "Sword",
            "Basic sword",
            WeaponType.Sword,
            [
                CreateProperty()
            ]);

        Assert.Equal("Sword", weapon.Name);
        Assert.Equal("Basic sword", weapon.Description);
        Assert.Equal(WeaponType.Sword, weapon.Type);
        Assert.Single(weapon.Properties);
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenNameEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Weapon(
                "",
                "Description",
                WeaponType.Sword,
                [
                    CreateProperty()
                ]));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenDescriptionEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Weapon(
                "Sword",
                "",
                WeaponType.Sword,
                [
                    CreateProperty()
                ]));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenWeaponTypeInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new Weapon(
                "Sword",
                "Description",
                (WeaponType)999,
                [
                    CreateProperty()
                ]));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenPropertiesEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Weapon(
                "Sword",
                "Description",
                WeaponType.Sword,
                []));
    }


    [Fact]
    public void Constructor_ShouldAddProperties_WhenPropertiesValid()
    {
        var property = CreateProperty();

        var weapon = new Weapon(
            "Sword",
            "Description",
            WeaponType.Sword,
            [
                property
            ]);

        Assert.Contains(property, weapon.Properties);
    }
}