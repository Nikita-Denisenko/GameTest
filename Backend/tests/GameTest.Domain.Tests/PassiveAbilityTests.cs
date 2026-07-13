using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Tests.ValueObjects;

public class PassiveAbilityTests
{
    [Fact]
    public void Constructor_ShouldCreate_WhenValidData()
    {
        // Arrange
        var abilityName = "Increased Damage";
        var bonus = 15;
        var description = "Increases damage dealt by 15%";
        var type = PassiveAbilityType.IncreasedDamage;


        // Act
        var ability = new PassiveAbility(
            abilityName,
            bonus,
            description,
            type);


        // Assert
        Assert.Equal(abilityName, ability.Name);
        Assert.Equal(bonus, ability.Bonus);
        Assert.Equal(description, ability.Description);
        Assert.Equal(type, ability.Type);
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenNameIsEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new PassiveAbility(
                string.Empty,
                15,
                "Increases damage dealt by 15%",
                PassiveAbilityType.IncreasedDamage));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenNameIsWhitespace()
    {
        Assert.Throws<DomainException>(() =>
            new PassiveAbility(
                "   ",
                15,
                "Increases damage dealt by 15%",
                PassiveAbilityType.IncreasedDamage));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenDescriptionIsEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new PassiveAbility(
                "Increased Damage",
                15,
                string.Empty,
                PassiveAbilityType.IncreasedDamage));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenDescriptionIsWhitespace()
    {
        Assert.Throws<DomainException>(() =>
            new PassiveAbility(
                "Increased Damage",
                15,
                "   ",
                PassiveAbilityType.IncreasedDamage));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenBonusIsNegative()
    {
        Assert.Throws<DomainException>(() =>
            new PassiveAbility(
                "Increased Damage",
                -10,
                "Increases damage dealt by 15%",
                PassiveAbilityType.IncreasedDamage));
    }
}