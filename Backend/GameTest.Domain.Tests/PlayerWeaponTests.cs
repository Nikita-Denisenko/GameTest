using GameTest.Domain.Entities;
using GameTest.Domain.Enums;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Tests;

public class PlayerWeaponTests
{
    private Weapon CreateWeapon()
    {
        var stat = new WeaponStat(
            "Damage",
            "Weapon damage",
            WeaponStatType.Damage);

        var property = new WeaponProperty(
            stat,
            [
                new LevelProgression(1, 10, 100),
                new LevelProgression(2, 20, 200)
            ]);

        return new Weapon(
            "Sword",
            "Basic sword",
            WeaponType.Sword,
            [
                property
            ]);
    }


    [Fact]
    public void Constructor_ShouldCreatePlayerWeapon_WhenWeaponValid()
    {
        var weapon = CreateWeapon();

        var playerWeapon = new PlayerWeapon(weapon);

        Assert.Equal(weapon, playerWeapon.Weapon);
        Assert.Equal(weapon.Id, playerWeapon.WeaponId);
    }


    [Fact]
    public void Constructor_ShouldCopyWeaponProperties()
    {
        var weapon = CreateWeapon();

        var playerWeapon = new PlayerWeapon(weapon);

        Assert.Equal(
            weapon.Properties.Count,
            playerWeapon.Properties.Count);
    }
}