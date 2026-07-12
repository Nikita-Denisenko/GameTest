using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Tests;

public class EnemyTests
{
    private EnemyProperty CreateProperty()
    {
        var stat = new EnemyStat(
            "MaxHealth",
            "Maximum health",
            EnemyStatType.MaxHealth);

        return new EnemyProperty(
            stat,
            100);
    }


    [Fact]
    public void Constructor_ShouldCreateEnemy_WhenDataValid()
    {
        var enemy = new Enemy(
            "Zombie",
            "Slow enemy",
            EnemyType.Normal,
            EnemyAttackType.Melee,
            [
                CreateProperty()
            ]);

        Assert.Equal("Zombie", enemy.Name);
        Assert.Equal("Slow enemy", enemy.Description);
        Assert.Equal(EnemyType.Normal, enemy.Type);
        Assert.Equal(EnemyAttackType.Melee, enemy.AttackType);
        Assert.Single(enemy.Properties);
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenNameEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Enemy(
                "",
                "Description",
                EnemyType.Normal,
                EnemyAttackType.Melee,
                [
                    CreateProperty()
                ]));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenDescriptionEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Enemy(
                "Zombie",
                "",
                EnemyType.Normal,
                EnemyAttackType.Melee,
                [
                    CreateProperty()
                ]));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenEnemyTypeInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new Enemy(
                "Zombie",
                "Description",
                (EnemyType)999,
                EnemyAttackType.Melee,
                [
                    CreateProperty()
                ]));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenAttackTypeInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new Enemy(
                "Zombie",
                "Description",
                EnemyType.Normal,
                (EnemyAttackType)999,
                [
                    CreateProperty()
                ]));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenPropertiesEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new Enemy(
                "Zombie",
                "Description",
                EnemyType.Normal,
                EnemyAttackType.Melee,
                []));
    }


    [Fact]
    public void Constructor_ShouldAddProperties_WhenPropertiesValid()
    {
        var property = CreateProperty();

        var enemy = new Enemy(
            "Zombie",
            "Description",
            EnemyType.Normal,
            EnemyAttackType.Melee,
            [
                property
            ]);

        Assert.Contains(property, enemy.Properties);
    }
}