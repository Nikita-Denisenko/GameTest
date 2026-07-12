using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Tests;

public class UnitStatTests
{
    [Fact]
    public void Constructor_ShouldCreateUnitStat_WhenDataValid()
    {
        var stat = new UnitStat(
            "MaxHealth",
            "Maximum health",
            UnitStatType.MaxHealth);

        Assert.Equal("MaxHealth", stat.Name);
        Assert.Equal("Maximum health", stat.Description);
        Assert.Equal(UnitStatType.MaxHealth, stat.Type);
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenNameEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new UnitStat(
                "",
                "Description",
                UnitStatType.MaxHealth));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenDescriptionEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new UnitStat(
                "MaxHealth",
                "",
                UnitStatType.MaxHealth));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenTypeInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new UnitStat(
                "MaxHealth",
                "Description",
                (UnitStatType)999));
    }
}