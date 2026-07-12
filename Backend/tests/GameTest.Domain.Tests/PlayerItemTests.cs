using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Tests;

public class PlayerItemTests
{
    private Item CreateItem()
    {
        return new Item(
            "Boots",
            "Increase movement speed",
            ItemType.Boots,
            "Move Speed",
            "Increase movement speed bonus",
            ItemEffectType.MoveSpeed,
            [
                new LevelProgression(1, 5, 100),
                new LevelProgression(2, 10, 200),
                new LevelProgression(3, 15, 300)
            ]);
    }


    [Fact]
    public void Constructor_ShouldCreatePlayerItem_WhenLevelValid()
    {
        var item = CreateItem();

        var playerItem = new PlayerItem(item);

        Assert.Equal(item, playerItem.Item);
        Assert.Equal(item.Id, playerItem.ItemId);
        Assert.Equal(1, playerItem.Level);
        Assert.Equal(5, playerItem.Bonus);
        Assert.Equal(200, playerItem.NextLevelPrice);
        Assert.Equal(10, playerItem.NextLevelBonus);
    }


    [Fact]
    public void Constructor_ShouldCreatePlayerItem_WithCustomLevel()
    {
        var item = CreateItem();

        var playerItem = new PlayerItem(item, 2);

        Assert.Equal(2, playerItem.Level);
        Assert.Equal(10, playerItem.Bonus);
        Assert.Equal(300, playerItem.NextLevelPrice);
        Assert.Equal(15, playerItem.NextLevelBonus);
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenLevelLessThanOne()
    {
        Assert.Throws<DomainException>(() =>
            new PlayerItem(CreateItem(), 0));
    }


    [Fact]
    public void UpLevel_ShouldIncreaseLevel_WhenUpgradeAvailable()
    {
        var playerItem = new PlayerItem(CreateItem());

        playerItem.UpLevel();

        Assert.Equal(2, playerItem.Level);
        Assert.Equal(10, playerItem.Bonus);
        Assert.Equal(300, playerItem.NextLevelPrice);
        Assert.Equal(15, playerItem.NextLevelBonus);
    }


    [Fact]
    public void UpLevel_ShouldUpdateBonus_WhenLevelIncreased()
    {
        var playerItem = new PlayerItem(CreateItem());

        playerItem.UpLevel();

        Assert.Equal(10, playerItem.Bonus);
    }


    [Fact]
    public void UpLevel_ShouldThrowDomainException_WhenMaxLevelReached()
    {
        var playerItem = new PlayerItem(CreateItem(), 3);

        Assert.Throws<DomainException>(() =>
            playerItem.UpLevel());
    }


    [Fact]
    public void CanUpgrade_ShouldReturnTrue_WhenNextLevelExists()
    {
        var playerItem = new PlayerItem(CreateItem());

        Assert.True(playerItem.CanUpgrade);
    }


    [Fact]
    public void CanUpgrade_ShouldReturnFalse_WhenMaxLevelReached()
    {
        var playerItem = new PlayerItem(CreateItem(), 3);

        Assert.False(playerItem.CanUpgrade);
    }
}