using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Tests;

public class EnemyPropertyTests
{
    private EnemyStat CreateStat()
    {
        return new EnemyStat(
            "Damage",
            "Enemy damage",
            EnemyStatType.Damage);
    }


    [Fact]
    public void Constructor_ShouldCreateProperty_WhenDataValid()
    {
        var stat = CreateStat();

        var property = new EnemyProperty(
            stat,
            25);

        Assert.Equal(stat, property.Stat);
        Assert.Equal(stat.Id, property.StatId);
        Assert.Equal(25, property.Value);
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenValueNegative()
    {
        Assert.Throws<DomainException>(() =>
            new EnemyProperty(
                CreateStat(),
                -10));
    }


    [Fact]
    public void Constructor_ShouldAllowZeroValue()
    {
        var property = new EnemyProperty(
            CreateStat(),
            0);

        Assert.Equal(0, property.Value);
    }
}