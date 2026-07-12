using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Tests;

public class PlayerWeaponPropertyTests
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
                new LevelProgression(1, 10, 100),
                new LevelProgression(2, 20, 200),
                new LevelProgression(3, 30, 300)
            ]);
    }


    [Fact]
    public void Constructor_ShouldCreatePlayerProperty()
    {
        var property = new PlayerWeaponProperty(
            CreateProperty());

        Assert.Equal(1, property.Level);
        Assert.Equal(10, property.Value);
        Assert.True(property.CanUpgrade);
    }


    [Fact]
    public void Constructor_ShouldThrow_WhenPropertyNull()
    {
        Assert.Throws<DomainException>(() =>
            new PlayerWeaponProperty(null!));
    }


    [Fact]
    public void Constructor_ShouldThrow_WhenLevelInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new PlayerWeaponProperty(
                CreateProperty(),
                0));
    }


    [Fact]
    public void UpLevel_ShouldIncreaseLevel()
    {
        var property = new PlayerWeaponProperty(
            CreateProperty());

        property.UpLevel();

        Assert.Equal(2, property.Level);
        Assert.Equal(20, property.Value);
    }


    [Fact]
    public void UpLevel_ShouldThrow_WhenMaxLevelReached()
    {
        var property = new PlayerWeaponProperty(
            CreateProperty(),
            3);

        Assert.Throws<DomainException>(() =>
            property.UpLevel());
    }


    [Fact]
    public void CanUpgrade_ShouldBeFalse_WhenMaxLevel()
    {
        var property = new PlayerWeaponProperty(
            CreateProperty(),
            3);

        Assert.False(property.CanUpgrade);
    }
}