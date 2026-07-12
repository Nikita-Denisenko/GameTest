using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Tests;

public class PlayerUnitPropertyTests
{
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
                new LevelProgression(2, 150, 200),
                new LevelProgression(3, 200, 300)
            ]);
    }


    [Fact]
    public void Constructor_ShouldCreateProperty_WhenDataValid()
    {
        var property = new PlayerUnitProperty(
            CreateProperty());

        Assert.Equal(1, property.Level);
        Assert.Equal(100, property.Value);
        Assert.True(property.CanUpgrade);
    }


    [Fact]
    public void Constructor_ShouldThrow_WhenPropertyNull()
    {
        Assert.Throws<DomainException>(() =>
            new PlayerUnitProperty(null!));
    }


    [Fact]
    public void Constructor_ShouldThrow_WhenLevelInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new PlayerUnitProperty(
                CreateProperty(),
                0));
    }


    [Fact]
    public void UpLevel_ShouldIncreaseLevelAndValue()
    {
        var property = new PlayerUnitProperty(
            CreateProperty());

        property.UpLevel();

        Assert.Equal(2, property.Level);
        Assert.Equal(150, property.Value);
    }


    [Fact]
    public void UpLevel_ShouldThrow_WhenMaxLevel()
    {
        var property = new PlayerUnitProperty(
            CreateProperty(),
            3);

        Assert.Throws<DomainException>(() =>
            property.UpLevel());
    }


    [Fact]
    public void CanUpgrade_ShouldBeFalse_WhenMaxLevel()
    {
        var property = new PlayerUnitProperty(
            CreateProperty(),
            3);

        Assert.False(property.CanUpgrade);
    }
}