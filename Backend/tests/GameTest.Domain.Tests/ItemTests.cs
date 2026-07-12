using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Tests;

public class ItemTests
{
    private List<LevelProgression> CreateLevels()
    {
        return
        [
            new LevelProgression(1, 5, 100),
            new LevelProgression(2, 10, 200),
            new LevelProgression(3, 15, 300)
        ];
    }


    [Fact]
    public void Constructor_ShouldCreateItem_WhenDataValid()
    {
        var item = new Item(
            "Swift Boots",
            "Increase movement speed",
            ItemType.Boots,
            "Movement Speed",
            "Increase player movement speed",
            ItemEffectType.MoveSpeed,
            CreateLevels());

        Assert.Equal("Swift Boots", item.Name);
        Assert.Equal("Increase movement speed", item.Description);
        Assert.Equal(ItemType.Boots, item.Type);

        Assert.NotNull(item.Effect);
        Assert.Equal("Movement Speed", item.Effect.Name);
        Assert.Equal(ItemEffectType.MoveSpeed, item.Effect.Type);
    }


    [Fact]
    public void Constructor_ShouldCalculateMaxLevel_FromEffectLevels()
    {
        var item = new Item(
            "Gloves",
            "Increase attack speed",
            ItemType.Gloves,
            "Attack Speed",
            "Increase attack speed",
            ItemEffectType.AttackSpeed,
            CreateLevels());

        Assert.Equal(3, item.MaxLevel);
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenNameEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Item(
                "",
                "Description",
                ItemType.Boots,
                "Effect",
                "Effect description",
                ItemEffectType.MoveSpeed,
                CreateLevels()));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenDescriptionEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Item(
                "Boots",
                "",
                ItemType.Boots,
                "Effect",
                "Effect description",
                ItemEffectType.MoveSpeed,
                CreateLevels()));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenItemTypeInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new Item(
                "Boots",
                "Description",
                (ItemType)999,
                "Effect",
                "Effect description",
                ItemEffectType.MoveSpeed,
                CreateLevels()));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenEffectNameEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Item(
                "Boots",
                "Description",
                ItemType.Boots,
                "",
                "Effect description",
                ItemEffectType.MoveSpeed,
                CreateLevels()));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenEffectDescriptionEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Item(
                "Boots",
                "Description",
                ItemType.Boots,
                "Effect",
                "",
                ItemEffectType.MoveSpeed,
                CreateLevels()));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenEffectTypeInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new Item(
                "Boots",
                "Description",
                ItemType.Boots,
                "Effect",
                "Effect description",
                (ItemEffectType)999,
                CreateLevels()));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenLevelsEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Item(
                "Boots",
                "Description",
                ItemType.Boots,
                "Effect",
                "Effect description",
                ItemEffectType.MoveSpeed,
                []));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenLevelsNull()
    {
        Assert.Throws<DomainException>(() =>
            new Item(
                "Boots",
                "Description",
                ItemType.Boots,
                "Effect",
                "Effect description",
                ItemEffectType.MoveSpeed,
                null!));
    }
}