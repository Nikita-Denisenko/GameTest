using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Tests;

public class WeaponStatTests
{
    [Fact]
    public void Constructor_ShouldCreateWeaponStat_WhenDataValid()
    {
        var stat = new WeaponStat(
            "Damage",
            "Weapon damage bonus",
            WeaponStatType.Damage);

        Assert.Equal("Damage", stat.Name);
        Assert.Equal("Weapon damage bonus", stat.Description);
        Assert.Equal(WeaponStatType.Damage, stat.Type);
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenNameEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new WeaponStat(
                "",
                "Description",
                WeaponStatType.Damage));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenDescriptionEmpty()
    {
        Assert.Throws<DomainException>(() =>
            new WeaponStat(
                "Damage",
                "",
                WeaponStatType.Damage));
    }


    [Fact]
    public void Constructor_ShouldThrowDomainException_WhenTypeInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new WeaponStat(
                "Damage",
                "Description",
                (WeaponStatType)999));
    }
}