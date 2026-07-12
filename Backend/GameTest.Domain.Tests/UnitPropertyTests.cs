using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Tests;

public class UnitPropertyTests
{
    private UnitStat CreateStat()
    {
        return new UnitStat(
            "MaxHealth",
            "Maximum health",
            UnitStatType.MaxHealth);
    }


    private List<LevelProgression> CreateLevels()
    {
        return
        [
            new LevelProgression(1, 100, 100),
            new LevelProgression(2, 150, 200),
            new LevelProgression(3, 200, 300)
        ];
    }


    [Fact]
    public void Constructor_ShouldCreateProperty_WhenDataValid()
    {
        var property = new UnitProperty(
            CreateStat(),
            CreateLevels());

        Assert.Equal(3, property.MaxLevel);
        Assert.Equal("MaxHealth", property.Name);
        Assert.Equal(UnitStatType.MaxHealth, property.StatType);
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenLevelsEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new UnitProperty(
                CreateStat(),
                []));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenLevelsNull()
    {
        Assert.Throws<DomainException>(() =>
            new UnitProperty(
                CreateStat(),
                null!));
    }


    [Fact]
    public void GetValueAtLevel_ShouldReturnCorrectValue()
    {
        var property = new UnitProperty(
            CreateStat(),
            CreateLevels());

        var value = property.GetValueAtLevel(2);

        Assert.Equal(150, value);
    }


    [Fact]
    public void GetValueAtLevel_ShouldThrow_WhenLevelNotExists()
    {
        var property = new UnitProperty(
            CreateStat(),
            CreateLevels());

        Assert.Throws<DomainException>(() =>
            property.GetValueAtLevel(10));
    }


    [Fact]
    public void GetNextLevelPrice_ShouldReturnNextPrice()
    {
        var property = new UnitProperty(
            CreateStat(),
            CreateLevels());

        var price = property.GetNextLevelPrice(1);

        Assert.Equal(200, price);
    }


    [Fact]
    public void GetNextLevelValue_ShouldReturnNextValue()
    {
        var property = new UnitProperty(
            CreateStat(),
            CreateLevels());

        var value = property.GetNextLevelValue(1);

        Assert.Equal(150, value);
    }


    [Fact]
    public void GetNextLevelPrice_ShouldReturnNull_WhenMaxLevelReached()
    {
        var property = new UnitProperty(
            CreateStat(),
            CreateLevels());

        var price = property.GetNextLevelPrice(3);

        Assert.Null(price);
    }


    [Fact]
    public void GetNextLevelValue_ShouldReturnNull_WhenMaxLevelReached()
    {
        var property = new UnitProperty(
            CreateStat(),
            CreateLevels());

    var value = property.GetNextLevelValue(3);

    Assert.Null(value);
    }
}