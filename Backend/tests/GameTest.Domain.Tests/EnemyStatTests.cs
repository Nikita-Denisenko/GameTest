using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Tests;

public class EnemyStatTests
{
    [Fact]
    public void Constructor_ShouldCreateEnemyStat_WhenDataValid()
    {
        var stat = new EnemyStat(
            "MaxHealth",
            "Maximum enemy health",
            EnemyStatType.MaxHealth);

        Assert.Equal("MaxHealth", stat.Name);
        Assert.Equal("Maximum enemy health", stat.Description);
        Assert.Equal(EnemyStatType.MaxHealth, stat.Type);
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenNameEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new EnemyStat(
                "",
                "Description",
                EnemyStatType.MaxHealth));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenDescriptionEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new EnemyStat(
                "MaxHealth",
                "",
                EnemyStatType.MaxHealth));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenTypeInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new EnemyStat(
                "MaxHealth",
                "Description",
                (EnemyStatType)999));
    }
}