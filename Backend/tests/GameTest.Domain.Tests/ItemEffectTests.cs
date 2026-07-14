using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Tests.ValueObjects;

public class ItemEffectTests
{
    private static List<LevelProgression> CreateLevels()
    {
        return
        [
            new LevelProgression(1, 10, 100),
            new LevelProgression(2, 20, 200),
            new LevelProgression(3, 30, 300)
        ];
    }


    [Fact]
    public void Constructor_ShouldCreate_WhenValidData()
    {
        var effect = new ItemEffect(
            "Damage",
            "Increase damage",
            ItemEffectType.Damage,
            CreateLevels());

        Assert.Equal("Damage", effect.Name);
        Assert.Equal(ItemEffectType.Damage, effect.Type);
        Assert.Equal(3, effect.Levels.Count);
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenNameEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new ItemEffect(
                "",
                "Description",
                ItemEffectType.Damage,
                CreateLevels()));
    }


    [Fact]
    public void GetValueAtLevel_ShouldReturnValue_WhenLevelExists()
    {
        var effect = new ItemEffect(
            "Damage",
            "Increase damage",
            ItemEffectType.Damage,
            CreateLevels());


        var result = effect.GetValueAtLevel(2);


        Assert.Equal(20, result);
    }


    [Fact]
    public void GetValueAtLevel_ShouldThrow_WhenLevelNotExists()
    {
        var effect = new ItemEffect(
            "Damage",
            "Increase damage",
            ItemEffectType.Damage,
            CreateLevels());


        Assert.Throws<DomainException>(() =>
            effect.GetValueAtLevel(99));
    }


    [Fact]
    public void GetNextLevelPrice_ShouldReturnPrice_WhenNextLevelExists()
    {
        var effect = new ItemEffect(
            "Damage",
            "Increase damage",
            ItemEffectType.Damage,
            CreateLevels());


        var result = effect.GetNextLevelPrice(1);


        Assert.Equal(200, result);
    }


    [Fact]
    public void GetNextLevelPrice_ShouldReturnNull_WhenMaxLevel()
    {
        var effect = new ItemEffect(
            "Damage",
            "Increase damage",
            ItemEffectType.Damage,
            CreateLevels());


        var result = effect.GetNextLevelPrice(3);


        Assert.Null(result);
    }
}