using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Tests.ValueObjects;

public class LevelProgressionTests
{
    [Fact]
    public void Constructor_ShouldCreate_WhenValidData()
    {
        var progression = new LevelProgression(
            1,
            10.5,
            100);

        Assert.Equal(1, progression.Level);
        Assert.Equal(10.5, progression.Value);
        Assert.Equal(100, progression.Price);
    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_ShouldThrowDomainException_WhenLevelInvalid(int level)
    {
        Assert.Throws<DomainException>(() =>
            new LevelProgression(
                level,
                10,
                100));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenValueNegative()
    {
        Assert.Throws<DomainException>(() =>
            new LevelProgression(
                1,
                -1,
                100));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenPriceNegative()
    {
        Assert.Throws<DomainException>(() =>
            new LevelProgression(
                1,
                10,
                -100));
    }
}