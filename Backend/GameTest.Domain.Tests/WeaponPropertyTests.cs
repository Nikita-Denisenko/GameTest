using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Tests;

public class WeaponPropertyTests
{
    private WeaponStat CreateStat()
    {
        return new WeaponStat(
            "Damage",
            "Weapon damage",
            WeaponStatType.Damage);
    }

    private List<LevelProgression> CreateLevels()
    {
        return
        [
            new LevelProgression(1, 10, 100),
            new LevelProgression(2, 20, 200),
            new LevelProgression(3, 30, 300)
        ];
    }

    [Fact]
    public void Constructor_ShouldCreateProperty_WhenDataValid()
    {
        var property = new WeaponProperty(
            CreateStat(),
            CreateLevels());

        Assert.Equal(3, property.MaxLevel);
        Assert.Equal("Damage", property.Name);
    }


    [Fact]
    public void Constructor_ShouldThrow_WhenLevelsEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new WeaponProperty(
                CreateStat(),
                []));
    }


    [Fact]
    public void Constructor_ShouldThrow_WhenStatNull()
    {
        Assert.Throws<DomainException>(() =>
            new WeaponProperty(
                null!,
                CreateLevels()));
    }


    [Fact]
    public void GetValueAtLevel_ShouldReturnValue()
    {
        var property = new WeaponProperty(
            CreateStat(),
            CreateLevels());

        var result = property.GetValueAtLevel(2);

        Assert.Equal(20, result);
    }


    [Fact]
    public void GetValueAtLevel_ShouldThrow_WhenLevelNotExists()
    {
        var property = new WeaponProperty(
            CreateStat(),
            CreateLevels());

        Assert.Throws<DomainException>(() =>
            property.GetValueAtLevel(10));
    }


    [Fact]
    public void GetNextLevelPrice_ShouldReturnNextPrice()
    {
        var property = new WeaponProperty(
            CreateStat(),
            CreateLevels());

        var result = property.GetNextLevelPrice(1);

        Assert.Equal(200, result);
    }


    [Fact]
    public void GetNextLevelValue_ShouldReturnNextValue()
    {
        var property = new WeaponProperty(
            CreateStat(),
            CreateLevels());

        var result = property.GetNextLevelValue(1);

        Assert.Equal(20, result);
    }


    [Fact]
    public void GetNextLevelPrice_ShouldReturnNull_WhenMaxLevel()
    {
        var property = new WeaponProperty(
            CreateStat(),
            CreateLevels());

        var result = property.GetNextLevelPrice(3);

        Assert.Null(result);
    }
}